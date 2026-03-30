namespace DaintStudio.UserControls
{
    partial class BlockChain
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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabPage3 = new TabPage();
            button_chon_textbox = new Button();
            textBox_url = new TextBox();
            button_chon_combobox = new Button();
            comboBox_url = new ComboBox();
            webView22 = new Microsoft.Web.WebView2.WinForms.WebView2();
            tabPage_gate_io = new TabPage();
            button_xem_gia = new Button();
            textBox_symbol = new TextBox();
            textBox_secret = new TextBox();
            textBox_key = new TextBox();
            label_tong_tai_san = new Label();
            label_pnl = new Label();
            dataGridView1 = new DataGridView();
            label_future_total = new Label();
            button_save_key = new Button();
            label2 = new Label();
            label1 = new Label();
            dataGridView_spot = new DataGridView();
            button_xem_thong_tin = new Button();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            button1 = new Button();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView22).BeginInit();
            tabPage_gate_io.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_spot).BeginInit();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button_chon_textbox);
            tabPage3.Controls.Add(textBox_url);
            tabPage3.Controls.Add(button_chon_combobox);
            tabPage3.Controls.Add(comboBox_url);
            tabPage3.Controls.Add(webView22);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1031, 737);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Trình duyệt";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button_chon_textbox
            // 
            button_chon_textbox.Location = new Point(953, 6);
            button_chon_textbox.Name = "button_chon_textbox";
            button_chon_textbox.Size = new Size(75, 23);
            button_chon_textbox.TabIndex = 4;
            button_chon_textbox.Text = "Chọn";
            button_chon_textbox.UseVisualStyleBackColor = true;
            button_chon_textbox.Click += button_chon_textbox_Click;
            // 
            // textBox_url
            // 
            textBox_url.Location = new Point(614, 4);
            textBox_url.Name = "textBox_url";
            textBox_url.Size = new Size(333, 23);
            textBox_url.TabIndex = 3;
            // 
            // button_chon_combobox
            // 
            button_chon_combobox.Location = new Point(487, 4);
            button_chon_combobox.Name = "button_chon_combobox";
            button_chon_combobox.Size = new Size(121, 23);
            button_chon_combobox.TabIndex = 2;
            button_chon_combobox.Text = "Chọn";
            button_chon_combobox.UseVisualStyleBackColor = true;
            button_chon_combobox.Click += button_chon_combobox_Click;
            // 
            // comboBox_url
            // 
            comboBox_url.FormattingEnabled = true;
            comboBox_url.Location = new Point(6, 3);
            comboBox_url.Name = "comboBox_url";
            comboBox_url.Size = new Size(475, 23);
            comboBox_url.TabIndex = 1;
            // 
            // webView22
            // 
            webView22.AllowExternalDrop = true;
            webView22.CreationProperties = null;
            webView22.DefaultBackgroundColor = Color.White;
            webView22.Dock = DockStyle.Bottom;
            webView22.Location = new Point(3, 32);
            webView22.Name = "webView22";
            webView22.Size = new Size(1025, 702);
            webView22.TabIndex = 0;
            webView22.ZoomFactor = 1D;
            // 
            // tabPage_gate_io
            // 
            tabPage_gate_io.Controls.Add(button_xem_gia);
            tabPage_gate_io.Controls.Add(textBox_symbol);
            tabPage_gate_io.Controls.Add(textBox_secret);
            tabPage_gate_io.Controls.Add(textBox_key);
            tabPage_gate_io.Controls.Add(label_tong_tai_san);
            tabPage_gate_io.Controls.Add(label_pnl);
            tabPage_gate_io.Controls.Add(dataGridView1);
            tabPage_gate_io.Controls.Add(label_future_total);
            tabPage_gate_io.Controls.Add(button_save_key);
            tabPage_gate_io.Controls.Add(label2);
            tabPage_gate_io.Controls.Add(label1);
            tabPage_gate_io.Controls.Add(dataGridView_spot);
            tabPage_gate_io.Controls.Add(button_xem_thong_tin);
            tabPage_gate_io.Location = new Point(4, 24);
            tabPage_gate_io.Name = "tabPage_gate_io";
            tabPage_gate_io.Padding = new Padding(3);
            tabPage_gate_io.Size = new Size(1031, 737);
            tabPage_gate_io.TabIndex = 3;
            tabPage_gate_io.Text = "Gate.io";
            tabPage_gate_io.UseVisualStyleBackColor = true;
            // 
            // button_xem_gia
            // 
            button_xem_gia.Location = new Point(181, 117);
            button_xem_gia.Name = "button_xem_gia";
            button_xem_gia.Size = new Size(96, 23);
            button_xem_gia.TabIndex = 16;
            button_xem_gia.Text = "Xem Giá";
            button_xem_gia.UseVisualStyleBackColor = true;
            button_xem_gia.Click += button_xem_gia_Click;
            // 
            // textBox_symbol
            // 
            textBox_symbol.Location = new Point(87, 117);
            textBox_symbol.Name = "textBox_symbol";
            textBox_symbol.Size = new Size(88, 23);
            textBox_symbol.TabIndex = 15;
            // 
            // textBox_secret
            // 
            textBox_secret.Location = new Point(79, 79);
            textBox_secret.Name = "textBox_secret";
            textBox_secret.Size = new Size(499, 23);
            textBox_secret.TabIndex = 6;
            // 
            // textBox_key
            // 
            textBox_key.Location = new Point(79, 41);
            textBox_key.Name = "textBox_key";
            textBox_key.Size = new Size(499, 23);
            textBox_key.TabIndex = 5;
            // 
            // label_tong_tai_san
            // 
            label_tong_tai_san.AutoSize = true;
            label_tong_tai_san.Location = new Point(382, 10);
            label_tong_tai_san.Name = "label_tong_tai_san";
            label_tong_tai_san.Size = new Size(69, 15);
            label_tong_tai_san.TabIndex = 10;
            label_tong_tai_san.Text = "tổng tài sản";
            // 
            // label_pnl
            // 
            label_pnl.AutoSize = true;
            label_pnl.Location = new Point(291, 10);
            label_pnl.Name = "label_pnl";
            label_pnl.Size = new Size(46, 15);
            label_pnl.TabIndex = 9;
            label_pnl.Text = "Lãi/Lỗ: ";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(181, 161);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(397, 203);
            dataGridView1.TabIndex = 8;
            // 
            // label_future_total
            // 
            label_future_total.AutoSize = true;
            label_future_total.Location = new Point(158, 10);
            label_future_total.Name = "label_future_total";
            label_future_total.Size = new Size(80, 15);
            label_future_total.TabIndex = 7;
            label_future_total.Text = "Số dư Future: ";
            // 
            // button_save_key
            // 
            button_save_key.Location = new Point(6, 117);
            button_save_key.Name = "button_save_key";
            button_save_key.Size = new Size(75, 23);
            button_save_key.TabIndex = 4;
            button_save_key.Text = "Lưu Key";
            button_save_key.UseVisualStyleBackColor = true;
            button_save_key.Click += button_save_key_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 85);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 3;
            label2.Text = "Secret: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 44);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 2;
            label1.Text = "Key: ";
            // 
            // dataGridView_spot
            // 
            dataGridView_spot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_spot.Location = new Point(3, 160);
            dataGridView_spot.Name = "dataGridView_spot";
            dataGridView_spot.Size = new Size(172, 204);
            dataGridView_spot.TabIndex = 1;
            // 
            // button_xem_thong_tin
            // 
            button_xem_thong_tin.Location = new Point(6, 6);
            button_xem_thong_tin.Name = "button_xem_thong_tin";
            button_xem_thong_tin.Size = new Size(146, 23);
            button_xem_thong_tin.TabIndex = 0;
            button_xem_thong_tin.Text = "Xem";
            button_xem_thong_tin.UseVisualStyleBackColor = true;
            button_xem_thong_tin.Click += button_xem_thong_tin_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage_gate_io);
            tabControl.Controls.Add(tabPage3);
            tabControl.Controls.Add(tabPage1);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1039, 765);
            tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1031, 737);
            tabPage1.TabIndex = 4;
            tabPage1.Text = "Bingx";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(74, 50);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BlockChain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl);
            Name = "BlockChain";
            Size = new Size(1039, 765);
            Load += BlockChain_Load;
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView22).EndInit();
            tabPage_gate_io.ResumeLayout(false);
            tabPage_gate_io.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_spot).EndInit();
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPage3;
        private Button button_chon_textbox;
        private TextBox textBox_url;
        private Button button_chon_combobox;
        private ComboBox comboBox_url;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView22;
        private TabPage tabPage_gate_io;
        private Button button_xem_gia;
        private TextBox textBox_symbol;
        private TextBox textBox_secret;
        private TextBox textBox_key;
        private Label label_tong_tai_san;
        private Label label_pnl;
        private DataGridView dataGridView1;
        private Label label_future_total;
        private Button button_save_key;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView_spot;
        private Button button_xem_thong_tin;
        private TabControl tabControl;
        private TabPage tabPage1;
        private Button button1;
    }
}
