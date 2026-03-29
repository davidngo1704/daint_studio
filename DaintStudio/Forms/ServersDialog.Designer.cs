namespace DaintStudio.Forms
{
    partial class ServersDialog
    {

        private System.ComponentModel.IContainer components = null;

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
            comboBox1 = new ComboBox();
            button_chon = new Button();
            button_cancel = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(94, 75);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(197, 23);
            comboBox1.TabIndex = 0;
            // 
            // button_chon
            // 
            button_chon.Location = new Point(94, 125);
            button_chon.Name = "button_chon";
            button_chon.Size = new Size(98, 23);
            button_chon.TabIndex = 1;
            button_chon.Text = "Chọn";
            button_chon.UseVisualStyleBackColor = true;
            button_chon.Click += button_chon_Click;
            // 
            // button_cancel
            // 
            button_cancel.Location = new Point(202, 125);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new Size(89, 23);
            button_cancel.TabIndex = 2;
            button_cancel.Text = "Hủy";
            button_cancel.UseVisualStyleBackColor = true;
            button_cancel.Click += button_cancel_Click;
            // 
            // ServersDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 233);
            Controls.Add(button_cancel);
            Controls.Add(button_chon);
            Controls.Add(comboBox1);
            Name = "ServersDialog";
            Text = "ServersDialog";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private Button button_chon;
        private Button button_cancel;
    }
}