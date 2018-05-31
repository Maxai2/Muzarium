using Muzarium.Common;
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
        }

        private ICommand clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (this.clickCommand is null)
                {
                    this.clickCommand = new RelayCommand(
                        (param) =>
                        {
                            FakePass.Text = PassBox.Password;

                            PassBox.Visibility = Visibility.Collapsed;
                            FakePass.Visibility = Visibility.Visible;


                        },
                        (param) =>
                        {
                            if (PassBox.Password == String.Empty)
                                return false;
                            else
                                return true;
                        });
                }
                return this.clickCommand;
            }
        }

    }
}
