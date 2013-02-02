using System;
using System.IO;
using System.Windows;

namespace BugTracker {
    public partial class AddBug : Window {
        public AddBug(string currentUser, string currentProject) {
            InitializeComponent();
            Username.Content = currentUser;
            ProjectName.Content = currentProject;
        }

        private void OK_Click(object sender, RoutedEventArgs e) {           
            StreamWriter sw = File.AppendText(@".\Bugs.csv");
            sw.WriteLine("");
            sw.Write("7," + ProjectName.Content + "," + Username.Content + "," + DateTime.Now + "," + BugName.Text + "," + BugDescription.Text + ",X" + ",X");
            sw.Flush();
            sw.Close();

            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }
    }
}