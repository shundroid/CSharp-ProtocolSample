using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace ProtocolTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey regkey = Registry.ClassesRoot.CreateSubKey(@"protocoltest");
            regkey.SetValue("", "URL:C# Test Protocol");
            regkey.SetValue("URL Protocol", "");
            RegistryKey openCommand = regkey.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command");
            openCommand.SetValue("", "\"C:\\Windows\\notepad.exe\" \"%1");
            openCommand.Close();
            regkey.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("protocoltest:");
        }
    }
}
