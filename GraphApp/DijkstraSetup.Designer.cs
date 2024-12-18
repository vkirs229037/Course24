namespace GraphApp
{
    partial class DijkstraSetup
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
            label1 = new Label();
            startComboBox = new ComboBox();
            endComboBox = new ComboBox();
            okBtn = new Button();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(48, 40);
            label1.Name = "label1";
            label1.Size = new Size(264, 62);
            label1.TabIndex = 0;
            label1.Text = "Выберите начальную и \r\nконечную вершины";
            // 
            // startComboBox
            // 
            startComboBox.FormattingEnabled = true;
            startComboBox.Location = new Point(53, 146);
            startComboBox.Name = "startComboBox";
            startComboBox.Size = new Size(259, 28);
            startComboBox.TabIndex = 1;
            // 
            // endComboBox
            // 
            endComboBox.FormattingEnabled = true;
            endComboBox.Location = new Point(53, 206);
            endComboBox.Name = "endComboBox";
            endComboBox.Size = new Size(259, 28);
            endComboBox.TabIndex = 2;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(12, 296);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(163, 62);
            okBtn.TabIndex = 3;
            okBtn.Text = "ОК";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(199, 296);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(163, 62);
            cancelBtn.TabIndex = 4;
            cancelBtn.Text = "Отмена";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // DijkstraSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 380);
            Controls.Add(cancelBtn);
            Controls.Add(okBtn);
            Controls.Add(endComboBox);
            Controls.Add(startComboBox);
            Controls.Add(label1);
            Name = "DijkstraSetup";
            Text = "Настройка";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox startComboBox;
        private ComboBox endComboBox;
        private Button okBtn;
        private Button cancelBtn;
    }
}