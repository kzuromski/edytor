using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edytor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadPlugins();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "*.rtf";
            saveFile.Filter = "RTF Files|*.rtf";
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
            {
                richTextBox1.SaveFile(saveFile.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "*.rtf";
            openFile.Filter = "RTF Files|*.rtf";
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFile.FileName.Length > 0)
            {
                richTextBox1.LoadFile(openFile.FileName);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void LoadPlugins()
        {
            foreach (string myFilename in Directory.GetFiles(@"..\..\bin\Debug\", "*.dll", SearchOption.AllDirectories))
            {
                Assembly plugin = Assembly.LoadFrom(myFilename);
                foreach (Type item in plugin.GetTypes()) //lista klas
                    foreach (MethodInfo method in item.GetMethods(BindingFlags.Public | BindingFlags.Static))
                    {
                        wtyczkiToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(method.Name, null, MenuHandler, myFilename + "|" + item.Name + "|" + method.Name));
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string description = "Opis " + textBox1.Text;
            string name = "Nazwa" + textBox1.Text;
            if (!wtyczkiToolStripMenuItem.DropDownItems.ContainsKey(name))
            {
                wtyczkiToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(description, null, MenuHandler, name));
            }
        }

        private void MenuHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem positon = (ToolStripMenuItem)sender;

            string[] names = positon.Name.Split(new char[] { '|' });
            string NazwaAssembly = names[0];
            string NazwaKlasy = names[1];
            string NazwaMetody = names[2];


            Assembly plugin = Assembly.LoadFrom(NazwaAssembly);
            string[] fullAssebmly = plugin.FullName.Split(new char[] { ',' });
            string NazwaNamespace = fullAssebmly[0];
            //ładowanie klasy o konkretnej nazwie
            System.Type item = plugin.GetType(NazwaNamespace + '.' + NazwaKlasy, true);
            MethodInfo method = item.GetMethod(NazwaMetody);
            object result = method.Invoke(null, new object[] { richTextBox1});
        }
    }
}
