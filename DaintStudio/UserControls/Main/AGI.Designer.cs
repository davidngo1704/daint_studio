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
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listBox_agents);
            splitContainer1.Size = new Size(1054, 730);
            splitContainer1.SplitterDistance = 221;
            splitContainer1.TabIndex = 0;
            // 
            // listBox_agents
            // 
            listBox_agents.Dock = DockStyle.Fill;
            listBox_agents.FormattingEnabled = true;
            listBox_agents.Location = new Point(0, 0);
            listBox_agents.Name = "listBox_agents";
            listBox_agents.Size = new Size(221, 730);
            listBox_agents.TabIndex = 0;
            // 
            // AGI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "AGI";
            Size = new Size(1054, 730);
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ListBox listBox_agents;
    }
}
