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
            try {
                StreamReader file = new StreamReader(@".\CurrentData.csv");
                string line = file.ReadLine();
                String[] data = line.Split(',');
                file.Close();

                ArrayList list = new ArrayList();
                file = new StreamReader(@".\Users.csv");
                while ((line = file.ReadLine()) != null) {
                    String[] users = line.Split(',');
                    list.Add(users);
                }
                for (int i = 0; i < list.Count; i++) {
                    string[] user = (string[])(list[i]);
                    if (data[0].Equals(user[0])) {
                        currentUser = data[0];
                        currentProject = data[1];
                        Menu_Open.IsEnabled = true;
                        Menu_New.IsEnabled = true;
                        Menu_Add.IsEnabled = true;
                    }
                }
                file.Close();
                spawnDialog = false;
                OpenProject_Click(new object(), new RoutedEventArgs());
                spawnDialog = true;
                Session.Header = currentUser + " on " + currentProject;
            }
            catch (Exception e) {
                //Do nothing, because we don't care if there's no previously-saved data.
            }
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

        bool spawnDialog = true;

        private void OpenProject_Click(object sender, RoutedEventArgs e) {
            if (spawnDialog) {
                var dialog = new OpenProject();
                dialog.ShowDialog();
                if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                    currentProject = ((string)((ComboBoxItem)(dialog.ProjectList.SelectedItem)).Content);
            }
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
            Menu_Add.IsEnabled = true;

            StreamWriter sw = new StreamWriter(@".\CurrentData.csv");
            sw.Write(currentUser + "," + currentProject);
            sw.Flush();
            sw.Close();
            Session.Header = currentUser + " on " + currentProject;
        }

        private void NewProject_Click(object sender, RoutedEventArgs e) {
            var dialog = new NewProject();
            dialog.ShowDialog();
            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value) {
                currentProject = dialog.ProjectName.Text;
                Menu_Add.IsEnabled = true;
                StreamWriter sw = new StreamWriter(@".\CurrentData.csv");
                sw.Write(currentUser + "," + currentProject);
                sw.Flush();
                sw.Close();
                Session.Header = currentUser + " on " + currentProject;
            } 
        }

        private void SetUser_Click(object sender, RoutedEventArgs e) {
            var dialog = new SetUser();
            dialog.ShowDialog();
            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value) {
                currentUser = dialog.UsernameBox.Text;
                Menu_Open.IsEnabled = true;
                Menu_New.IsEnabled = true;
                Session.Header = currentUser;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}