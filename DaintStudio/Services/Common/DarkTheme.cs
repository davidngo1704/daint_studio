
namespace DaintStudio.Services.Common;

public static class DarkTheme
{
    public static Color BackColor = Color.FromArgb(30, 30, 30);
    public static Color ControlColor = Color.FromArgb(45, 45, 48);
    public static Color ForeColor = Color.White;

    public static void Apply(Control parent)
    {

        foreach (Control c in parent.Controls)
        {
            bool isCommon = 
                c is TreeView || 
                c is RichTextBox || 
                c is Panel || 
                c is GroupBox ||
                c is MenuStrip ||
                c is ListBox
                ;

            if (c is Form)
                c.BackColor = BackColor;

            if (c is Button)
            {
                c.BackColor = ControlColor;
                c.ForeColor = ForeColor;
                ((Button)c).FlatStyle = FlatStyle.Flat;
            }
            else if (c is TextBox || c is ComboBox)
            {
                c.BackColor = ControlColor;
                c.ForeColor = ForeColor;
            }
            else if (c is Label)
            {
                c.ForeColor = ForeColor;
            }

            else if(isCommon)
            {
                c.BackColor = BackColor;
                c.ForeColor = ForeColor;
            }
            else if (c is DataGridView dgv)
            {
                dgv.BackgroundColor = BackColor;
                dgv.ForeColor = ForeColor;
                dgv.GridColor = ControlColor;

                dgv.ColumnHeadersDefaultCellStyle.BackColor = ControlColor;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = ForeColor;

                dgv.DefaultCellStyle.BackColor = BackColor;
                dgv.DefaultCellStyle.ForeColor = ForeColor;
                dgv.DefaultCellStyle.SelectionBackColor = ControlColor;
                dgv.DefaultCellStyle.SelectionForeColor = ForeColor;

                dgv.EnableHeadersVisualStyles = false; // để header nhận style custom
            }

            if (c.HasChildren)
                Apply(c);
        }
    }
}