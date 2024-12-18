namespace GraphApp
{
    partial class ReachabilitySetup
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
            vertexComboBox = new ComboBox();
            okBtn = new Button();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(74, 62);
            label1.Name = "label1";
            label1.Size = new Size(215, 31);
            label1.TabIndex = 0;
            label1.Text = "Выберите вершину";
            // 
            // vertexComboBox
            // 
            vertexComboBox.FormattingEnabled = true;
            vertexComboBox.Location = new Point(65, 121);
            vertexComboBox.Name = "vertexComboBox";
            vertexComboBox.Size = new Size(235, 28);
            vertexComboBox.TabIndex = 1;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(12, 214);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(148, 59);
            okBtn.TabIndex = 2;
            okBtn.Text = "ОК";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(194, 214);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(148, 59);
            cancelBtn.TabIndex = 3;
            cancelBtn.Text = "Отмена";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // ReachabilitySetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 297);
            Controls.Add(cancelBtn);
            Controls.Add(okBtn);
            Controls.Add(vertexComboBox);
            Controls.Add(label1);
            Name = "ReachabilitySetup";
            Text = "Настройка";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox vertexComboBox;
        private Button okBtn;
        private Button cancelBtn;
    }
}