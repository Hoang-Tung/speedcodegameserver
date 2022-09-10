namespace LetsCreateNetworkGame.Server.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpServerOperations = new System.Windows.Forms.GroupBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.grpServerStatusLog = new System.Windows.Forms.GroupBox();
            this.dgwServerStatusLog = new System.Windows.Forms.DataGridView();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpPlayers = new System.Windows.Forms.GroupBox();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.cmnuPlayers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnPlayersKick = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddEnemy = new System.Windows.Forms.Button();
            this.grpServerOperations.SuspendLayout();
            this.grpServerStatusLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwServerStatusLog)).BeginInit();
            this.grpPlayers.SuspendLayout();
            this.cmnuPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpServerOperations
            // 
            this.grpServerOperations.Controls.Add(this.btnStopServer);
            this.grpServerOperations.Controls.Add(this.btnStartServer);
            this.grpServerOperations.Location = new System.Drawing.Point(16, 15);
            this.grpServerOperations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpServerOperations.Name = "grpServerOperations";
            this.grpServerOperations.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpServerOperations.Size = new System.Drawing.Size(393, 65);
            this.grpServerOperations.TabIndex = 0;
            this.grpServerOperations.TabStop = false;
            this.grpServerOperations.Text = "Server Operations";
            // 
            // btnStopServer
            // 
            this.btnStopServer.Enabled = false;
            this.btnStopServer.Location = new System.Drawing.Point(196, 23);
            this.btnStopServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(180, 28);
            this.btnStopServer.TabIndex = 1;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(8, 23);
            this.btnStartServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(180, 28);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // grpServerStatusLog
            // 
            this.grpServerStatusLog.Controls.Add(this.dgwServerStatusLog);
            this.grpServerStatusLog.Location = new System.Drawing.Point(221, 87);
            this.grpServerStatusLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpServerStatusLog.Name = "grpServerStatusLog";
            this.grpServerStatusLog.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpServerStatusLog.Size = new System.Drawing.Size(653, 410);
            this.grpServerStatusLog.TabIndex = 1;
            this.grpServerStatusLog.TabStop = false;
            this.grpServerStatusLog.Text = "Server status log";
            // 
            // dgwServerStatusLog
            // 
            this.dgwServerStatusLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwServerStatusLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmMessage});
            this.dgwServerStatusLog.Location = new System.Drawing.Point(8, 23);
            this.dgwServerStatusLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgwServerStatusLog.Name = "dgwServerStatusLog";
            this.dgwServerStatusLog.RowHeadersWidth = 51;
            this.dgwServerStatusLog.Size = new System.Drawing.Size(637, 379);
            this.dgwServerStatusLog.TabIndex = 0;
            // 
            // clmId
            // 
            this.clmId.HeaderText = "Id";
            this.clmId.MinimumWidth = 6;
            this.clmId.Name = "clmId";
            this.clmId.Width = 125;
            // 
            // clmMessage
            // 
            this.clmMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmMessage.HeaderText = "Message";
            this.clmMessage.MinimumWidth = 6;
            this.clmMessage.Name = "clmMessage";
            // 
            // grpPlayers
            // 
            this.grpPlayers.Controls.Add(this.lstPlayers);
            this.grpPlayers.Location = new System.Drawing.Point(16, 87);
            this.grpPlayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPlayers.Name = "grpPlayers";
            this.grpPlayers.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPlayers.Size = new System.Drawing.Size(197, 410);
            this.grpPlayers.TabIndex = 2;
            this.grpPlayers.TabStop = false;
            this.grpPlayers.Text = "Players";
            // 
            // lstPlayers
            // 
            this.lstPlayers.ContextMenuStrip = this.cmnuPlayers;
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.ItemHeight = 16;
            this.lstPlayers.Location = new System.Drawing.Point(8, 23);
            this.lstPlayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(179, 372);
            this.lstPlayers.TabIndex = 0;
            // 
            // cmnuPlayers
            // 
            this.cmnuPlayers.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmnuPlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnPlayersKick});
            this.cmnuPlayers.Name = "cmnuPlayers";
            this.cmnuPlayers.Size = new System.Drawing.Size(106, 28);
            // 
            // cmnPlayersKick
            // 
            this.cmnPlayersKick.Name = "cmnPlayersKick";
            this.cmnPlayersKick.Size = new System.Drawing.Size(105, 24);
            this.cmnPlayersKick.Text = "Kick";
            this.cmnPlayersKick.Click += new System.EventHandler(this.cmnPlayersKick_Click);
            // 
            // btnAddEnemy
            // 
            this.btnAddEnemy.Location = new System.Drawing.Point(417, 38);
            this.btnAddEnemy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddEnemy.Name = "btnAddEnemy";
            this.btnAddEnemy.Size = new System.Drawing.Size(265, 28);
            this.btnAddEnemy.TabIndex = 3;
            this.btnAddEnemy.Text = "Add enemy for fun";
            this.btnAddEnemy.UseVisualStyleBackColor = true;
            this.btnAddEnemy.Click += new System.EventHandler(this.btnAddEnemy_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 507);
            this.Controls.Add(this.btnAddEnemy);
            this.Controls.Add(this.grpPlayers);
            this.Controls.Add(this.grpServerStatusLog);
            this.Controls.Add(this.grpServerOperations);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.grpServerOperations.ResumeLayout(false);
            this.grpServerStatusLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwServerStatusLog)).EndInit();
            this.grpPlayers.ResumeLayout(false);
            this.cmnuPlayers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpServerOperations;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.GroupBox grpServerStatusLog;
        private System.Windows.Forms.DataGridView dgwServerStatusLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMessage;
        private System.Windows.Forms.GroupBox grpPlayers;
        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.ContextMenuStrip cmnuPlayers;
        private System.Windows.Forms.ToolStripMenuItem cmnPlayersKick;
        private System.Windows.Forms.Button btnAddEnemy;
    }
}