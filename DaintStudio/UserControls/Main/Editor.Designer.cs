using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DaintStudio.UserControls
{
    partial class Editor
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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            treeView = new System.Windows.Forms.TreeView();
            buttonFolder = new System.Windows.Forms.Button();
            buttonRun = new System.Windows.Forms.Button();
            buttonSave = new System.Windows.Forms.Button();
            richTextBox = new RichTextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
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
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(buttonFolder);
            splitContainer1.Panel2.Controls.Add(buttonRun);
            splitContainer1.Panel2.Controls.Add(buttonSave);
            splitContainer1.Panel2.Controls.Add(richTextBox);
            splitContainer1.Size = new Size(1072, 878);
            splitContainer1.SplitterDistance = 291;
            splitContainer1.TabIndex = 0;
            // 
            // treeView
            // 
            treeView.Dock = DockStyle.Fill;
            treeView.Location = new Point(0, 0);
            treeView.Name = "treeView";
            treeView.Size = new Size(291, 878);
            treeView.TabIndex = 0;
            treeView.BeforeExpand += before_expand;
            treeView.NodeMouseClick += treeView1_NodeMouseClick;
            // 
            // buttonFolder
            // 
            buttonFolder.Location = new Point(3, 488);
            buttonFolder.Name = "buttonFolder";
            buttonFolder.Size = new Size(81, 23);
            buttonFolder.TabIndex = 3;
            buttonFolder.Text = "Chọn Folder";
            buttonFolder.UseVisualStyleBackColor = true;
            buttonFolder.Click += buttonFolder_Click;
            // 
            // buttonRun
            // 
            buttonRun.Location = new Point(171, 488);
            buttonRun.Name = "buttonRun";
            buttonRun.Size = new Size(75, 23);
            buttonRun.TabIndex = 2;
            buttonRun.Text = "Chạy";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Click += buttonRun_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(90, 488);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Lưu";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // richTextBox
            // 
            richTextBox.Dock = DockStyle.Top;
            richTextBox.Location = new Point(0, 0);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(777, 471);
            richTextBox.TabIndex = 0;
            richTextBox.Text = "";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "Editor";
            Size = new Size(1072, 878);
            Load += Form_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private RichTextBox richTextBox;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonSave;
        private ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button buttonFolder;

    }
}
