using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary2
{
    public class Class2
    {
        private static string getPluginName()
        {
            return "ToUpper";
        }

        public static void ToUpper(RichTextBox rich)
        {
            if (String.IsNullOrEmpty(rich.SelectedText))
            {
                rich.Text = rich.Text.ToUpper();
            }
            else
            {
                rich.SelectedText = rich.SelectedText.ToUpper();
            }
        }
    }
}
