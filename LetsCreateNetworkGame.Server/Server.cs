//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LetsCreateNetworkGame.OpenGL.Library;
using LetsCreateNetworkGame.Server.Commands;
using LetsCreateNetworkGame.Server.Managers;
using LetsCreateNetworkGame.Server.MyEventArgs;
using Lidgren.Network;

namespace LetsCreateNetworkGame.Server
{
    class Server
    {
        public event EventHandler<NewPlayerEventArgs> NewPlayerEvent;
        private readonly ManagerLogger _managerLogger;
        private List<GameRoom> _gameRooms;  
        private NetPeerConfiguration _config;
        public NetServer NetServer { get; private set; }

        public Server(ManagerLogger managerLogger)
        {
            _managerLogger = managerLogger;
            _gameRooms = new List<GameRoom>();
            _config = new NetPeerConfiguration("networkGame") { Port = 14241 };
            //_config = new NetPeerConfiguration("networkGame") { LocalAddress = IPAddress.Parse("127.0.0.1") };
            _config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
            NetServer = new NetServer(_config);      
        }

        public void Run()
        {
            NetServer.Start();
            Console.WriteLine("Server started...");
            _managerLogger.AddLogMessage("Server","Server started...");
            AddGameRoom(1);
            AddGameRoom(2);
            while (true)
            {
                NetIncomingMessage inc;
                if ((inc = NetServer.ReadMessage()) == null) continue;
                switch (inc.MessageType)
                {
                    case NetIncomingMessageType.ConnectionApproval:
                        var login = new LoginCommand();
                        var gameRoom = GetGameRoomById(inc.ReadString());
                        login.Run(_managerLogger, this, inc, null, gameRoom);
                        break;
                    case NetIncomingMessageType.Data:
                        Data(inc); 
                        break;
                }
            }
        }

        private void Data(NetIncomingMessage inc)
        {
            var packetType = (PacketType) inc.ReadByte();
            var gameRoom = GetGameRoomById(inc.ReadString());
            var command = PacketFactory.GetCommand(packetType); 
            command.Run(_managerLogger, this,inc, null, gameRoom);
        }


        public void SendNewPlayerEvent(string username, string gameGroupId)
        {
            if(NewPlayerEvent != null)
                NewPlayerEvent(this,new NewPlayerEventArgs(string.Format("{0}[{1}]",username, gameGroupId)));
        }

        public void KickPlayer(string username, string gameGroupId)
        {
            var command = PacketFactory.GetCommand(PacketType.Kick);
            var gameGroup = GetGameRoomById(gameGroupId);
            command.Run(_managerLogger,this, null, gameGroup.Players.FirstOrDefault(p => p.Player.Username == username),gameGroup);
        }

        public void KickEnemy(int UniqueID, string gameGroupId)
        {
            var command = new KickEnemyCommand();
            command.KickUniqueId = UniqueID;
            var gameGroup = GetGameRoomById(gameGroupId);
            command.Run(_managerLogger, this, null, null, gameGroup);

        }
        private GameRoom GetGameRoomById(string id)
        {
            var gameRoom = _gameRooms.FirstOrDefault(g => g.GameRoomId == id);
            if (gameRoom == null)
            {
                gameRoom = new GameRoom(id, this, _managerLogger, 1);
                _gameRooms.Add(gameRoom);
            }
            return gameRoom; 
        }
        
        public GameRoom GetGameRoomByLevel(int level)
        {
            var gameRoom = _gameRooms.FirstOrDefault(g => g.RoomLevel == level);
            
            return gameRoom;
        }

        private void AddGameRoom(int level)
        {
            var gameRoom = new GameRoom((new Random()).Next(0, 9999).ToString(), this, _managerLogger, level);
            _gameRooms.Add(gameRoom);
        }

        public string ChangeGameRoom(int level, PlayerAndConnection playerAndConnection)
        {
            string grID = "";
            var gameRoom = _gameRooms.FirstOrDefault(gr => gr.RoomLevel == level);
            gameRoom.Players.Add(playerAndConnection);
            grID = gameRoom.GameRoomId;
            return grID;
        }

        public void AddEnemy()
        {
            foreach (var gameRoom in _gameRooms)
            {
                gameRoom.AddEnemy();
            }
        }

    }
}
