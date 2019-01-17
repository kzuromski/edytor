using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary5
{
    public class Class5
    {
        private static string getPluginName()
        {
            return "Italic";
        }

        public static void Italic(RichTextBox rich)
        {
            if (String.IsNullOrEmpty(rich.SelectedText))
            {
                rich.Font = new Font(rich.Font, FontStyle.Italic);
            }
            else
            {
                rich.SelectionFont = new Font(rich.SelectionFont, FontStyle.Italic);
                
            }
        }
    }
}
