using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BugTracker {
    /// <summary>
    /// Interaction logic for OpenProject.xaml
    /// </summary>
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
