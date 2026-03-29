using DaintStudio.Services.Common;

namespace DaintStudio.UserControls
{
    public partial class AGI : UserControl
    {
        public AGI()
        {
            InitializeComponent();
            Dark_Mode();
        }
        private void Dark_Mode()
        {

            DarkTheme.Apply(this);

            this.BackColor = Color.FromArgb(30, 30, 30);

            this.ForeColor = Color.White;

        }

    }
}
