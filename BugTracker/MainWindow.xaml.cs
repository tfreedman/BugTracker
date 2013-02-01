using System.Windows;

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
            var dialog = new AddBug();
            dialog.ShowDialog();
        }

        private void OpenProject_Click(object sender, RoutedEventArgs e) {
            var dialog = new OpenProject();
            dialog.ShowDialog();
        }

        private void NewProject_Click(object sender, RoutedEventArgs e) {
            var dialog = new NewProject();
            dialog.ShowDialog();
        }

        private void SetUser_Click(object sender, RoutedEventArgs e) {
            var dialog = new SetUser();
            dialog.ShowDialog();
            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value) {
                currentUser = dialog.UsernameBox.Text;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
