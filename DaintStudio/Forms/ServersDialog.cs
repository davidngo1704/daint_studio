
using DaintStudio.Models;
using DaintStudio.Services.Common;

namespace DaintStudio.Forms
{
    public partial class ServersDialog : Form
    {
        public string serversFilePath = Path.Combine("D:\\ApiGateway", "data", "server", "list_server.json");
        public Server selectedServer = new Server();
        public List<Server> servers = new List<Server>();
        public ServersDialog()
        {
            InitializeComponent();

            try
            {
                servers = FileHelper.Read<List<Server>>(serversFilePath);

                foreach (var server in servers)
                {
                    comboBox1.Items.Add(server.name);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void button_chon_Click(object sender, EventArgs e)
        {
            selectedServer = servers.FirstOrDefault(m => m.name.Equals(comboBox1.SelectedItem.ToString()));

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
