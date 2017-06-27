namespace Puzzle
{
    partial class Game
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.NewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.setings = new System.Windows.Forms.ToolStripMenuItem();
            this.open = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameMode = new System.Windows.Forms.ToolStripMenuItem();
            this.editMode = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBarTime = new System.Windows.Forms.ToolStripProgressBar();
            this.scoreLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lifeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.boardPanel = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGame,
            this.setings,
            this.open,
            this.save,
            this.modeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(552, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // NewGame
            // 
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(93, 24);
            this.NewGame.Text = "New game";
            this.NewGame.Click += new System.EventHandler(this.newGame_Click);
            // 
            // setings
            // 
            this.setings.Name = "setings";
            this.setings.Size = new System.Drawing.Size(74, 24);
            this.setings.Text = "Settings";
            this.setings.Click += new System.EventHandler(this.setings_Click);
            // 
            // open
            // 
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(57, 24);
            this.open.Text = "Open";
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // save
            // 
            this.save.Enabled = false;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(52, 24);
            this.save.Text = "Save";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameMode,
            this.editMode});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // gameMode
            // 
            this.gameMode.Checked = true;
            this.gameMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gameMode.Name = "gameMode";
            this.gameMode.Size = new System.Drawing.Size(123, 26);
            this.gameMode.Text = "Game";
            this.gameMode.Click += new System.EventHandler(this.gameMode_Click);
            // 
            // editMode
            // 
            this.editMode.Name = "editMode";
            this.editMode.Size = new System.Drawing.Size(123, 26);
            this.editMode.Text = "Edit";
            this.editMode.Click += new System.EventHandler(this.editMode_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBarTime,
            this.scoreLabel,
            this.lifeLabel,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 423);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(552, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBarTime
            // 
            this.progressBarTime.AutoSize = false;
            this.progressBarTime.BackColor = System.Drawing.SystemColors.Control;
            this.progressBarTime.ForeColor = System.Drawing.Color.Lime;
            this.progressBarTime.MergeIndex = 1;
            this.progressBarTime.Name = "progressBarTime";
            this.progressBarTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressBarTime.RightToLeftLayout = true;
            this.progressBarTime.Size = new System.Drawing.Size(140, 19);
            this.progressBarTime.Step = 1;
            this.progressBarTime.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // scoreLabel
            // 
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(61, 20);
            this.scoreLabel.Text = "Score: 0";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lifeLabel
            // 
            this.lifeLabel.Name = "lifeLabel";
            this.lifeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lifeLabel.Size = new System.Drawing.Size(51, 20);
            this.lifeLabel.Text = "lifes: 0";
            this.lifeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(254, 20);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // boardPanel
            // 
            this.boardPanel.ColumnCount = 5;
            this.boardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.boardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.boardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.boardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.boardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.boardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.boardPanel.Location = new System.Drawing.Point(0, 28);
            this.boardPanel.Margin = new System.Windows.Forms.Padding(4);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.RowCount = 5;
            this.boardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.boardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.boardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.boardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.boardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.boardPanel.Size = new System.Drawing.Size(552, 395);
            this.boardPanel.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 448);
            this.Controls.Add(this.boardPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PuzzleGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem NewGame;
        private System.Windows.Forms.ToolStripMenuItem setings;
        private System.Windows.Forms.ToolStripMenuItem open;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameMode;
        private System.Windows.Forms.ToolStripMenuItem editMode;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBarTime;
        private System.Windows.Forms.TableLayoutPanel boardPanel;
        public System.Windows.Forms.ToolStripStatusLabel scoreLabel;
        private SettingsBox settingsBox = new SettingsBox();
        public System.Windows.Forms.ToolStripStatusLabel lifeLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

