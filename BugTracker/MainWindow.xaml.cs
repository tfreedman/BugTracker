using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BugTracker {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        
        string currentUser = "";
        string currentProject = "";

        public MainWindow() {
            InitializeComponent();
        }

        private void AddBug_Click(object sender, RoutedEventArgs e) {
            var dialog = new AddBug(currentUser, currentProject);
            dialog.ShowDialog();
        }

        private void resultDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            Bugs selectedBug = (Bugs)BugList.SelectedItems[0];
            var dialog = new BrowseBug(selectedBug.ID);
            dialog.ShowDialog();
        }

        private void OpenProject_Click(object sender, RoutedEventArgs e) {
            var dialog = new OpenProject();
            dialog.ShowDialog();
            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                currentProject = ((string)((ComboBoxItem)(dialog.ProjectList.SelectedItem)).Content);
            
            List<Bugs> bugs = new List<Bugs>();
            StreamReader file = new StreamReader(@".\Bugs.csv");
            string line;
            while ((line = file.ReadLine()) != null) {
                String[] bug = line.Split(',');
                bugs.Add(new Bugs() { ID = bug[0], Project = bug[1], Username = bug[2], Date = bug[3], Name = bug[4], Description = bug[5], Severity = bug[6], Type = bug[7] });
            }

            BugList.ItemsSource = bugs;
            BugList.Opacity = 1;
            file.Close();
        }

        private void NewProject_Click(object sender, RoutedEventArgs e) {
            var dialog = new NewProject();
            dialog.ShowDialog();
            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                currentProject = dialog.ProjectName.Text;
        }

        private void SetUser_Click(object sender, RoutedEventArgs e) {
            var dialog = new SetUser();
            dialog.ShowDialog();
            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                currentUser = dialog.UsernameBox.Text;
        }

        private void Exit_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}