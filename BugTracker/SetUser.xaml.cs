using System;
using System.Collections;
using System.Windows;

namespace BugTracker {
    /// <summary>
    /// Interaction logic for SetUser.xaml
    /// </summary>
    public partial class SetUser : Window {
        public SetUser() {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e) {
            ArrayList list = new ArrayList();
            System.IO.StreamReader file = new System.IO.StreamReader(@".\Users.csv");
            string line;
            while ((line = file.ReadLine()) != null) {
                String[] users = line.Split(',');
                list.Add(users);
            }
            bool validLogin = false;
            for (int i = 0; i < list.Count; i++) {
                string[] user = (string[])(list[i]);
                if (UsernameBox.Text.Equals(user[0]) && PasswordBox.Text.Equals(user[1])) {
                    validLogin = true;
                    this.DialogResult = true;
                }
            }

            if (!validLogin)
                MessageBox.Show("Invalid Username / Password, Please try again.");            
        }
    }
}
