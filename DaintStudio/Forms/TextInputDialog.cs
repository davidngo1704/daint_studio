namespace DaintStudio.Forms
{
    public partial class TextInputDialog : Form
    {

        public string UserInput = string.Empty;

        public TextInputDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserInput = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
