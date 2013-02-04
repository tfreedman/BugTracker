using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace BugTracker {
    public partial class NewProject : Window {

        public NewProject() {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e) {
            ArrayList list = new ArrayList();
            StreamReader file = new StreamReader(@".\Projects.csv");
            bool existingProjects = false;
            string line;
            while ((line = file.ReadLine()) != null) {
                String projects = line;
                list.Add(projects);
            }
            file.Close();
            for (int i = 0; i < list.Count; i++) {
                if (((string)(list[i])).Equals(ProjectName.Text)) {
                    MessageBox.Show("There's already a project with that name. Please pick a different name for the new project.");
                    existingProjects = true;
                    break;
                }
            }
            if (!existingProjects) {
                StreamWriter sw = File.AppendText(@".\Projects.csv");
                sw.Write(ProjectName.Text);
                sw.WriteLine("");
                sw.Flush();
                sw.Close();
                this.DialogResult = true;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }

    }
}
