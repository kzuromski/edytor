using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary4
{
    public class Class4
    {
        private static string getPluginName()
        {
            return "Bold";
        }

        public static void Bold(RichTextBox rich)
        {
            if (String.IsNullOrEmpty(rich.SelectedText))
            {
                rich.Font = new Font(rich.Font, FontStyle.Bold);
            }
            else
            {
                rich.SelectionFont = new Font(rich.SelectionFont, FontStyle.Bold);
                
            }
            
        }
    }
}
