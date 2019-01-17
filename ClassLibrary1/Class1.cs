using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class Class1
    {
        private static string getPluginName()
        {
            return "ToLower";
        }

        public static void ToLower(RichTextBox rich)
        {
            if (String.IsNullOrEmpty(rich.SelectedText))
            {
                rich.Text = rich.Text.ToLower();
            }
            else
            {
                rich.SelectedText = rich.SelectedText.ToLower();
            }
        }
    }
}
