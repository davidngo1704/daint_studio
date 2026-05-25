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
            nhạcToolStripMenuItem = new ToolStripMenuItem();
            nhạcTậpChungToolStripMenuItem = new ToolStripMenuItem();
            côngToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            giaoTiếpToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { giaoTiếpToolStripMenuItem, editorToolStripMenuItem, blockChainToolStripMenuItem, aGIToolStripMenuItem, roboticsToolStripMenuItem, nhạcToolStripMenuItem });
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
            // nhạcToolStripMenuItem
            // 
            nhạcToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nhạcTậpChungToolStripMenuItem, côngToolStripMenuItem });
            nhạcToolStripMenuItem.Name = "nhạcToolStripMenuItem";
            nhạcToolStripMenuItem.Size = new Size(68, 29);
            nhạcToolStripMenuItem.Text = "Nhạc";
            // 
            // nhạcTậpChungToolStripMenuItem
            // 
            nhạcTậpChungToolStripMenuItem.Name = "nhạcTậpChungToolStripMenuItem";
            nhạcTậpChungToolStripMenuItem.Size = new Size(248, 34);
            nhạcTậpChungToolStripMenuItem.Text = "Nhạc tập chung";
            nhạcTậpChungToolStripMenuItem.Click += nhạcTậpChungToolStripMenuItem_Click_1;
            // 
            // côngToolStripMenuItem
            // 
            côngToolStripMenuItem.Name = "côngToolStripMenuItem";
            côngToolStripMenuItem.Size = new Size(248, 34);
            côngToolStripMenuItem.Text = "Công  ty tư nhân";
            côngToolStripMenuItem.Click += côngToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 35);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1420, 1015);
            panel1.TabIndex = 1;
            // 
            // giaoTiếpToolStripMenuItem
            // 
            giaoTiếpToolStripMenuItem.Name = "giaoTiếpToolStripMenuItem";
            giaoTiếpToolStripMenuItem.Size = new Size(102, 29);
            giaoTiếpToolStripMenuItem.Text = "Giao Tiếp";
            giaoTiếpToolStripMenuItem.Click += giaoTiếpToolStripMenuItem_Click;
            // 
            // EntryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1420, 1050);
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
        private ToolStripMenuItem nhạcToolStripMenuItem;
        private ToolStripMenuItem nhạcTậpChungToolStripMenuItem;
        private ToolStripMenuItem côngToolStripMenuItem;
        private ToolStripMenuItem giaoTiếpToolStripMenuItem;
    }
}