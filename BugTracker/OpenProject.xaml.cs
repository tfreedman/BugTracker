using System.Windows;
using System.Windows.Controls;

namespace BugTracker {
    public partial class OpenProject : Window {
        public OpenProject() {
            InitializeComponent();
            System.IO.StreamReader file = new System.IO.StreamReader(@".\Projects.csv");
            string line;
            while ((line = file.ReadLine()) != null) {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = line;
                ProjectList.Items.Add(item);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }

        private void OK_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
        }
    }
}
