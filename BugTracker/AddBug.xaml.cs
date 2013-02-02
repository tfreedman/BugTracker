using System;
using System.IO;
using System.Windows;

namespace BugTracker {
    /// <summary>
    /// Interaction logic for AddBug.xaml
    /// </summary>
    public partial class AddBug : Window {
        public AddBug(string currentUser, string currentProject) {
            InitializeComponent();
            Username.Content = currentUser;
            ProjectName.Content = currentProject;
        }

        private void OK_Click(object sender, RoutedEventArgs e) {           
            StreamWriter sw = File.AppendText(@".\Bugs.csv");
            sw.WriteLine("");
            sw.Write("7");
            sw.Write(",");
            sw.Write(ProjectName.Content);
            sw.Write(",");
            sw.Write(Username.Content);
            sw.Write(",");
            sw.Write(DateTime.Now);
            sw.Write(",");
            sw.Write(BugName.Text);
            sw.Write(",");
            sw.Write(BugDescription.Text);
            sw.Flush();
            sw.Close();

            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }
    }
}
