using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace BugTracker {
    /// <summary>
    /// Interaction logic for AddBug.xaml
    /// </summary>
    public partial class BrowseBug : Window {
        public BrowseBug(string ID) {
            InitializeComponent();

            List<Bugs> bugs = new List<Bugs>();
            StreamReader file = new StreamReader(@".\Bugs.csv");
            string line;
            while ((line = file.ReadLine()) != null) {
                String[] bug = line.Split(',');
                if (bug[0].Equals(ID)) {
                    ProjectName.Content = bug[1];
                    Username.Content = bug[2];
                    BugDate.Content = bug[3];
                    BugName.Content = bug[4];
                    BugDescription.Content = bug[5];
                    BugSeverity.Content = bug[6];
                    BugType.Content = bug[7];
                    break;
                }
            }
            file.Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }
    }
}
