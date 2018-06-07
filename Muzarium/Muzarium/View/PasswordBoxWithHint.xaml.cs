using Muzarium.Common;
using Muzarium.Interface;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Muzarium.View
{
    /// <summary>
    /// Interaction logic for PasswordBoxWithHint.xaml
    /// </summary>
    public partial class PasswordBoxWithHint : UserControl
    {
        public PasswordBoxWithHint()
        {
            InitializeComponent();

            this.FakePass.Visibility = Visibility.Collapsed;
        }

        bool change = true;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (change)
            {
                PassBox.Visibility = Visibility.Collapsed;
                FakePass.Visibility = Visibility.Visible;
            }
            else
            {
                PassBox.Visibility = Visibility.Visible;
                FakePass.Visibility = Visibility.Collapsed;
            }

            change = !change;
        }
    }
}
