namespace TiltingMaze
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            NewGameMenuItem = new ToolStripMenuItem();
            Level1ToolStripMenuItem = new ToolStripMenuItem();
            Level2ToolStripMenuItem = new ToolStripMenuItem();
            Level3ToolStripMenuItem = new ToolStripMenuItem();
            UndoToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            timeLabel = new ToolStripStatusLabel();
            stepLabel = new ToolStripStatusLabel();
            gridPanel = new TableLayoutPanel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { newGameToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(1496, 35);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NewGameMenuItem, UndoToolStripMenuItem, toolStripMenuItem1, ExitToolStripMenuItem });
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.Size = new Size(74, 29);
            newGameToolStripMenuItem.Text = "Game";
            // 
            // NewGameMenuItem
            // 
            NewGameMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Level1ToolStripMenuItem, Level2ToolStripMenuItem, Level3ToolStripMenuItem });
            NewGameMenuItem.Name = "NewGameMenuItem";
            NewGameMenuItem.Size = new Size(270, 34);
            NewGameMenuItem.Text = "New Game (level1)";
            // 
            // Level1ToolStripMenuItem
            // 
            Level1ToolStripMenuItem.Name = "Level1ToolStripMenuItem";
            Level1ToolStripMenuItem.Size = new Size(270, 34);
            Level1ToolStripMenuItem.Text = "Level 1";
            Level1ToolStripMenuItem.Click += Level1ToolStripMenuItem_Click;
            // 
            // Level2ToolStripMenuItem
            // 
            Level2ToolStripMenuItem.Name = "Level2ToolStripMenuItem";
            Level2ToolStripMenuItem.Size = new Size(270, 34);
            Level2ToolStripMenuItem.Text = "Level 2";
            Level2ToolStripMenuItem.Click += Level2ToolStripMenuItem_Click;
            // 
            // Level3ToolStripMenuItem
            // 
            Level3ToolStripMenuItem.Name = "Level3ToolStripMenuItem";
            Level3ToolStripMenuItem.Size = new Size(270, 34);
            Level3ToolStripMenuItem.Text = "Level 3";
            Level3ToolStripMenuItem.Click += Level3ToolStripMenuItem_Click;
            // 
            // UndoToolStripMenuItem
            // 
            UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            UndoToolStripMenuItem.Size = new Size(270, 34);
            UndoToolStripMenuItem.Text = "Undo";
            UndoToolStripMenuItem.Click += UndoToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(267, 6);
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(270, 34);
            ExitToolStripMenuItem.Text = "Exit";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { timeLabel, stepLabel });
            statusStrip1.Location = new Point(0, 1051);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 20, 0);
            statusStrip1.Size = new Size(1496, 32);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // timeLabel
            // 
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(77, 25);
            timeLabel.Text = "Time: 0s";
            // 
            // stepLabel
            // 
            stepLabel.Name = "stepLabel";
            stepLabel.Size = new Size(74, 25);
            stepLabel.Text = "Steps: 0";
            // 
            // gridPanel
            // 
            gridPanel.BackColor = SystemColors.ActiveCaptionText;
            gridPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            gridPanel.ColumnCount = 2;
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gridPanel.Dock = DockStyle.Fill;
            gridPanel.Location = new Point(0, 35);
            gridPanel.Margin = new Padding(0);
            gridPanel.Name = "gridPanel";
            gridPanel.RowCount = 2;
            gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            gridPanel.Size = new Size(1496, 1016);
            gridPanel.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1496, 1083);
            Controls.Add(gridPanel);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Tilting Maze";
            KeyDown += Form1_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem NewGameMenuItem;
        private ToolStripMenuItem UndoToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel timeLabel;
        private ToolStripStatusLabel stepLabel;
        private TableLayoutPanel gridPanel;
        private ToolStripMenuItem Level1ToolStripMenuItem;
        private ToolStripMenuItem Level2ToolStripMenuItem;
        private ToolStripMenuItem Level3ToolStripMenuItem;
    }
}
