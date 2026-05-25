namespace DaintStudio.UserControls
{
    partial class AGI
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            listBox_agents = new ListBox();
            textBoxDimension = new TextBox();
            textBoxValue = new TextBox();
            textBoxToken = new TextBox();
            buttonNhap = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(4, 5, 4, 5);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listBox_agents);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(textBoxDimension);
            splitContainer1.Panel2.Controls.Add(textBoxValue);
            splitContainer1.Panel2.Controls.Add(textBoxToken);
            splitContainer1.Panel2.Controls.Add(buttonNhap);
            splitContainer1.Size = new Size(1506, 1217);
            splitContainer1.SplitterDistance = 315;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 0;
            // 
            // listBox_agents
            // 
            listBox_agents.Dock = DockStyle.Fill;
            listBox_agents.FormattingEnabled = true;
            listBox_agents.Location = new Point(0, 0);
            listBox_agents.Margin = new Padding(4, 5, 4, 5);
            listBox_agents.Name = "listBox_agents";
            listBox_agents.Size = new Size(315, 1217);
            listBox_agents.TabIndex = 0;
            // 
            // textBoxDimension
            // 
            textBoxDimension.Location = new Point(769, 54);
            textBoxDimension.Name = "textBoxDimension";
            textBoxDimension.Size = new Size(150, 31);
            textBoxDimension.TabIndex = 3;
            // 
            // textBoxValue
            // 
            textBoxValue.Location = new Point(339, 54);
            textBoxValue.Name = "textBoxValue";
            textBoxValue.Size = new Size(424, 31);
            textBoxValue.TabIndex = 2;
            // 
            // textBoxToken
            // 
            textBoxToken.BorderStyle = BorderStyle.None;
            textBoxToken.Location = new Point(65, 54);
            textBoxToken.Name = "textBoxToken";
            textBoxToken.Size = new Size(268, 24);
            textBoxToken.TabIndex = 1;
            // 
            // buttonNhap
            // 
            buttonNhap.Location = new Point(925, 54);
            buttonNhap.Name = "buttonNhap";
            buttonNhap.Size = new Size(112, 34);
            buttonNhap.TabIndex = 0;
            buttonNhap.Text = "Nhập";
            buttonNhap.UseVisualStyleBackColor = true;
            buttonNhap.Click += buttonNhap_Click;
            // 
            // AGI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AGI";
            Size = new Size(1506, 1217);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ListBox listBox_agents;
        private TextBox textBoxDimension;
        private TextBox textBoxValue;
        private TextBox textBoxToken;
        private Button buttonNhap;
    }
}
