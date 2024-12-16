﻿namespace GraphApp
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
            HelpToolStripMenuItem = new ToolStripMenuItem();
            AboutToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            достижимыеВершиныToolStripMenuItem = new ToolStripMenuItem();
            кратчайшийПутьToolStripMenuItem = new ToolStripMenuItem();
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
            GraphToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { достижимыеВершиныToolStripMenuItem, кратчайшийПутьToolStripMenuItem });
            GraphToolStripMenuItem.Name = "GraphToolStripMenuItem";
            GraphToolStripMenuItem.Size = new Size(57, 24);
            GraphToolStripMenuItem.Text = "Граф";
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
            // достижимыеВершиныToolStripMenuItem
            // 
            достижимыеВершиныToolStripMenuItem.Name = "достижимыеВершиныToolStripMenuItem";
            достижимыеВершиныToolStripMenuItem.Size = new Size(262, 26);
            достижимыеВершиныToolStripMenuItem.Text = "Достижимые вершины...";
            // 
            // кратчайшийПутьToolStripMenuItem
            // 
            кратчайшийПутьToolStripMenuItem.Name = "кратчайшийПутьToolStripMenuItem";
            кратчайшийПутьToolStripMenuItem.Size = new Size(262, 26);
            кратчайшийПутьToolStripMenuItem.Text = "Кратчайший путь...";
            // 
            // GraphForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 553);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "GraphForm";
            Text = "Grapher";
            Load += GraphForm_Load;
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
        private ToolStripMenuItem достижимыеВершиныToolStripMenuItem;
        private ToolStripMenuItem кратчайшийПутьToolStripMenuItem;
    }
}
