namespace DaintStudio
{
    partial class EntryForm
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


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
            menuStrip1 = new MenuStrip();
            editorToolStripMenuItem = new ToolStripMenuItem();
            blockChainToolStripMenuItem = new ToolStripMenuItem();
            aGIToolStripMenuItem = new ToolStripMenuItem();
            roboticsToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { editorToolStripMenuItem, blockChainToolStripMenuItem, aGIToolStripMenuItem, roboticsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(1420, 35);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // editorToolStripMenuItem
            // 
            editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            editorToolStripMenuItem.Size = new Size(75, 29);
            editorToolStripMenuItem.Text = "Editor";
            editorToolStripMenuItem.Click += editorToolStripMenuItem_Click;
            // 
            // blockChainToolStripMenuItem
            // 
            blockChainToolStripMenuItem.Name = "blockChainToolStripMenuItem";
            blockChainToolStripMenuItem.Size = new Size(114, 29);
            blockChainToolStripMenuItem.Text = "BlockChain";
            blockChainToolStripMenuItem.Click += blockChainToolStripMenuItem_Click;
            // 
            // aGIToolStripMenuItem
            // 
            aGIToolStripMenuItem.Name = "aGIToolStripMenuItem";
            aGIToolStripMenuItem.Size = new Size(57, 29);
            aGIToolStripMenuItem.Text = "AGI";
            aGIToolStripMenuItem.Click += aGIToolStripMenuItem_Click;
            // 
            // roboticsToolStripMenuItem
            // 
            roboticsToolStripMenuItem.Name = "roboticsToolStripMenuItem";
            roboticsToolStripMenuItem.Size = new Size(97, 29);
            roboticsToolStripMenuItem.Text = "Robotics";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 35);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1420, 1262);
            panel1.TabIndex = 1;
            // 
            // EntryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1420, 1297);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            Name = "EntryForm";
            Text = "EntryForm";
            Load += EntryForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem editorToolStripMenuItem;
        private ToolStripMenuItem blockChainToolStripMenuItem;
        private ToolStripMenuItem aGIToolStripMenuItem;
        private ToolStripMenuItem roboticsToolStripMenuItem;
        private Panel panel1;
    }
}