using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary3
{
    public class Class3
    {
        private static string getPluginName()
        {
            return "Reverse";
        }

        public static void Reverse(RichTextBox rich)
        {
            if (String.IsNullOrEmpty(rich.SelectedText))
            {
                char[] r = rich.Text.ToCharArray();
                Array.Reverse(r);
                rich.Text = new string(r);
            }
            else
            {
                char[] r = rich.SelectedText.ToCharArray();
                Array.Reverse(r);
                rich.SelectedText = new string(r);
            }
            
        }
    }
}
