using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NAudio.Wave;

namespace DaintStudio.UserControls.Main
{
    public partial class GiaoTiepUserControl : UserControl
    {
        private WaveInEvent waveSource;
        private WaveFileWriter waveFile;
        public GiaoTiepUserControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            waveSource.StopRecording();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            waveSource = new WaveInEvent();

            waveSource.WaveFormat = new WaveFormat(44100, 1);

            waveSource.DataAvailable += WaveSource_DataAvailable;
            waveSource.RecordingStopped += WaveSource_RecordingStopped;

            waveFile = new WaveFileWriter("record.wav", waveSource.WaveFormat);

            waveSource.StartRecording();

            MessageBox.Show("Bắt đầu thu âm");
        }
        private void WaveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }
        private void WaveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            waveSource.Dispose();
            waveSource = null;

            waveFile.Dispose();
            waveFile = null;

            MessageBox.Show("Đã lưu file record.wav");
        }
    }
}
