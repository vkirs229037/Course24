namespace GraphApp
{
    partial class GraphForm
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
            menuStrip = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            OpenFileToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            GraphToolStripMenuItem = new ToolStripMenuItem();
            reachableBtn = new ToolStripMenuItem();
            dijkstraBtn = new ToolStripMenuItem();
            HelpToolStripMenuItem = new ToolStripMenuItem();
            AboutToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            answerLabel = new Label();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, GraphToolStripMenuItem, HelpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(643, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenFileToolStripMenuItem, ExitToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(59, 24);
            FileToolStripMenuItem.Text = "Файл";
            // 
            // OpenFileToolStripMenuItem
            // 
            OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            OpenFileToolStripMenuItem.Size = new Size(198, 26);
            OpenFileToolStripMenuItem.Text = "Открыть файл...";
            OpenFileToolStripMenuItem.Click += OpenFileToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(198, 26);
            ExitToolStripMenuItem.Text = "Выход";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // GraphToolStripMenuItem
            // 
            GraphToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reachableBtn, dijkstraBtn });
            GraphToolStripMenuItem.Name = "GraphToolStripMenuItem";
            GraphToolStripMenuItem.Size = new Size(57, 24);
            GraphToolStripMenuItem.Text = "Граф";
            // 
            // reachableBtn
            // 
            reachableBtn.Name = "reachableBtn";
            reachableBtn.Size = new Size(262, 26);
            reachableBtn.Text = "Достижимые вершины...";
            reachableBtn.Click += reachableBtn_Click;
            // 
            // dijkstraBtn
            // 
            dijkstraBtn.Name = "dijkstraBtn";
            dijkstraBtn.Size = new Size(262, 26);
            dijkstraBtn.Text = "Кратчайший путь...";
            dijkstraBtn.Click += dijkstraBtn_Click;
            // 
            // HelpToolStripMenuItem
            // 
            HelpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AboutToolStripMenuItem });
            HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            HelpToolStripMenuItem.Size = new Size(81, 24);
            HelpToolStripMenuItem.Text = "Справка";
            // 
            // AboutToolStripMenuItem
            // 
            AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            AboutToolStripMenuItem.Size = new Size(187, 26);
            AboutToolStripMenuItem.Text = "О программе";
            AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // answerLabel
            // 
            answerLabel.AutoSize = true;
            answerLabel.Location = new Point(12, 524);
            answerLabel.Name = "answerLabel";
            answerLabel.Size = new Size(0, 20);
            answerLabel.TabIndex = 1;
            // 
            // GraphForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 553);
            Controls.Add(answerLabel);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "GraphForm";
            Text = "Grapher";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem OpenFileToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem GraphToolStripMenuItem;
        private ToolStripMenuItem HelpToolStripMenuItem;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private ToolStripMenuItem reachableBtn;
        private ToolStripMenuItem dijkstraBtn;
        private Label answerLabel;
    }
}
