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
            newGameMenuItem = new ToolStripMenuItem();
            level1ToolStripMenuItem = new ToolStripMenuItem();
            level2ToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            timeLabel = new ToolStripStatusLabel();
            stepLabel = new ToolStripStatusLabel();
            gridPanel = new TableLayoutPanel();
            level3ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { newGameToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1047, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameMenuItem, undoToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.Size = new Size(50, 20);
            newGameToolStripMenuItem.Text = "Game";
            // 
            // newGameMenuItem
            // 
            newGameMenuItem.DropDownItems.AddRange(new ToolStripItem[] { level1ToolStripMenuItem, level2ToolStripMenuItem, level3ToolStripMenuItem });
            newGameMenuItem.Name = "newGameMenuItem";
            newGameMenuItem.Size = new Size(180, 22);
            newGameMenuItem.Text = "New Game (level1)";
            // 
            // level1ToolStripMenuItem
            // 
            level1ToolStripMenuItem.Name = "level1ToolStripMenuItem";
            level1ToolStripMenuItem.Size = new Size(180, 22);
            level1ToolStripMenuItem.Text = "level1";
            level1ToolStripMenuItem.Click += level1ToolStripMenuItem_Click;
            // 
            // level2ToolStripMenuItem
            // 
            level2ToolStripMenuItem.Name = "level2ToolStripMenuItem";
            level2ToolStripMenuItem.Size = new Size(180, 22);
            level2ToolStripMenuItem.Text = "level2";
            level2ToolStripMenuItem.Click += level2ToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(180, 22);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { timeLabel, stepLabel });
            statusStrip1.Location = new Point(0, 628);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1047, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // timeLabel
            // 
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(51, 17);
            timeLabel.Text = "Time: 0s";
            // 
            // stepLabel
            // 
            stepLabel.Name = "stepLabel";
            stepLabel.Size = new Size(47, 17);
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
            gridPanel.Location = new Point(0, 24);
            gridPanel.Margin = new Padding(0);
            gridPanel.Name = "gridPanel";
            gridPanel.RowCount = 2;
            gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            gridPanel.Size = new Size(1047, 604);
            gridPanel.TabIndex = 2;
            // 
            // level3ToolStripMenuItem
            // 
            level3ToolStripMenuItem.Name = "level3ToolStripMenuItem";
            level3ToolStripMenuItem.Size = new Size(180, 22);
            level3ToolStripMenuItem.Text = "level3";
            level3ToolStripMenuItem.Click += level3ToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1047, 650);
            Controls.Add(gridPanel);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
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
        private ToolStripMenuItem newGameMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel timeLabel;
        private ToolStripStatusLabel stepLabel;
        private TableLayoutPanel gridPanel;
        private ToolStripMenuItem level1ToolStripMenuItem;
        private ToolStripMenuItem level2ToolStripMenuItem;
        private ToolStripMenuItem level3ToolStripMenuItem;
    }
}
