using System.Windows;
using System.Windows.Controls;

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

        private void OpenProject_Click(object sender, RoutedEventArgs e) {
            var dialog = new OpenProject();
            dialog.ShowDialog();
            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                currentProject = ((string)((ComboBoxItem)(dialog.ProjectList.SelectedItem)).Content);
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