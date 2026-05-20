
using DaintStudio.Models;
using DaintStudio.Services.Blockchain;
using DaintStudio.Services.Common;
using System.Data;
using System.Diagnostics;
using System.Text.Json;

namespace DaintStudio.UserControls
{
    public partial class BlockChain : UserControl
    {
        public BlockChain()
        {
            InitializeComponent();
            Dark_Mode();
        }

        private static KeyModel keyData = FileHelper.Read<KeyModel>(@"D:\ApiGateway\data\secret_keys\gate_io\key.json");

        private void BlockChain_Load(object sender, EventArgs e)
        {
            var urls = new List<string>();

            urls = FileHelper.Read<List<string>>(@"D:\ApiGateway\data\config\url.json");

            comboBox_url.DataSource = urls;

            textBox_key.Text = keyData?.key;

            textBox_secret.Text = keyData?.secret;
        }

        async void ActiveWebView(string url)
        {

            await webView22.EnsureCoreWebView2Async();

            webView22.CoreWebView2.Navigate(url);

        }

        private void Dark_Mode()
        {

            DarkTheme.Apply(this);

            this.BackColor = Color.FromArgb(30, 30, 30);

            this.ForeColor = Color.White;

        }

        private async void button_chon_combobox_Click(object sender, EventArgs e)
        {
            var selectedUrl = comboBox_url.SelectedItem as string;

            ActiveWebView(selectedUrl!);
        }

        private async void button_xem_thong_tin_Click(object sender, EventArgs e)
        {
            var client = new GateIoClient();

            var resultString = await client.GetSpotBalance();

            var spotBalance = JsonService.FromJson<List<SpotBalance>>(resultString);

            DataTable dt = new DataTable();

            dt.Columns.Add("Mã");

            dt.Columns.Add("Tiền");

            decimal totalSpot = 0;

            foreach (var item in spotBalance!)
            {
                dt.Rows.Add(item.currency, item.available);

                if (item.currency == "USDT")
                {
                    totalSpot += item.available;
                }
            }

            dataGridView_spot.DataSource = dt;

            var futureResultString = await client.GetFutureBalance();

            var futureBalance = JsonService.FromJson<FutureBalance>(futureResultString);

            label_future_total.Text = $"Số dư Future: {futureBalance!.total}$";

            label_pnl.Text = $"Lãi/Lỗ: {futureBalance.unrealised_pnl}$";

            label_tong_tai_san.Text = $"Tổng tài sản: {futureBalance.total + totalSpot}$";

            var vithefuture = await client.GetFuturePositions();



        }

        private void button_save_key_Click(object sender, EventArgs e)
        {
            keyData.key = textBox_key.Text;

            keyData.secret = textBox_secret.Text;

            FileHelper.Write(@"D:\ApiGateway\data\secret_keys\gate_io\key.json", keyData);

            MessageBox.Show("Đã lưu thành công!");
        }

        private void button_xem_gia_Click(object sender, EventArgs e)
        {
            try
            {
                string scriptPath = @"D:\ApiGateway\python\crypto\xem_gia_coin.py";

                string argParam = textBox_symbol.Text;

                string arg = $"{argParam}-USDT";

                var psi = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = $"\"{scriptPath}\" {arg}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();

                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(error))
                        MessageBox.Show(error);
                    else
                        MessageBox.Show(output);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_mua_spot_Click(object sender, EventArgs e)
        {

        }

        private void button_ban_spot_Click(object sender, EventArgs e)
        {

        }

        private void button_chon_textbox_Click(object sender, EventArgs e)
        {
            var url = textBox_url.Text?.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please enter a URL.");
                return;
            }

            // If user omitted scheme, assume https
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                url = "https://" + url;
            }

            try
            {
                ActiveWebView(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open URL: " + ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            KeyModel keyObject = FileHelper.ReadeFile<KeyModel>("D:\\database\\assets\\keys\\bingx_read_key.json");

            var data = new BingXClient(keyObject.key!, keyObject.secret!);

            var res = await data.GetFuturesPositionsAsync();

            MessageBox.Show(res);
        }
    }
}
