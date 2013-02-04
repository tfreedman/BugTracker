using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace BugTracker {
    public partial class AddBug : Window {

        public AddBug(string currentUser, string currentProject) {
            InitializeComponent();
            Username.Content = currentUser;
            ProjectName.Content = currentProject;
            System.IO.StreamReader file = new System.IO.StreamReader(@".\SeverityLevels.csv");
            System.IO.StreamReader file2 = new System.IO.StreamReader(@".\BugTypes.csv");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = line;
                Severity.Items.Add(item);
            }
            while ((line = file2.ReadLine()) != null)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = line;
                BugType.Items.Add(item);
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e) {           
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }

        public void Write_Bug(string severity, string bugType)
        {
            StreamWriter sw = File.AppendText(@".\Bugs.csv");
            sw.Write("7," + ProjectName.Content + "," + Username.Content + "," + DateTime.Now + "," + BugName.Text + "," + BugDescription.Text + "," + severity + "," + bugType);
            sw.WriteLine("");
            sw.Flush();
            sw.Close();
        }
    }
}