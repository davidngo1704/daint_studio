using DaintStudio.Services.Common;
using DaintStudio.UserControls;
using NAudio.Wave;

namespace DaintStudio
{
    public partial class EntryForm : Form
    {
        private WaveOutEvent? outputDevice;

        private AudioFileReader? audioFile;
        public EntryForm()
        {
            InitializeComponent();
        }
        private void EntryForm_Load(object sender, EventArgs e)
        {
            Dark_Mode();

            editorToolStripMenuItem_Click(sender, e);
        }
        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editor = new Editor();
            editor.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(editor);
        }
        private void blockChainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = new BlockChain();
            control.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(control);
        }
        private void aGIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = new AGI();
            control.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(control);
        }


        private void Dark_Mode()
        {

            DarkTheme.Apply(this);

            this.BackColor = Color.FromArgb(30, 30, 30);

            this.ForeColor = Color.White;

        }

        private bool isPlaying = false;

        private void nhạcTậpChungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(StaticData.RootDrive, "my_git", "assets", "music", "nhac_tap_trung.mp3");

            if (isPlaying)
            {
                StopMp3();
                isPlaying = false;
            }
            else
            {
                PlayMp3(path);
                isPlaying = true;
            }
        }

        private void PlayMp3(string path)
        {
            outputDevice = new WaveOutEvent();

            audioFile = new AudioFileReader(path);

            outputDevice.Init(audioFile);

            outputDevice.Play();
        }

        private void StopMp3()
        {
            outputDevice?.Stop();

            outputDevice?.Dispose();

            audioFile?.Dispose();
        }

        
    }
}
