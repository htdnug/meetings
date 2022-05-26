using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace HTDNUG.PictureList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string[] filters = { "*.jpg", "*.jpeg", "*.png", "*.gif", "*.bmp" };

            var directory = new DirectoryInfo(textBox1.Text);

            var files = new List<FileInfo>();

            foreach (var filter in filters)
            {
                var results = directory.GetFiles(filter, SearchOption.AllDirectories);
                files.AddRange(results);
            }

            foreach (var file in files)
            {
                listBox1.Items.Add(file.Name);
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string path = dialog.SelectedPath;
                textBox1.Text = path;    
            }    
        }
    }
}
