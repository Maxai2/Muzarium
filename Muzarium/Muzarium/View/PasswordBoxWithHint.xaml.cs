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

        }

        bool change = true;

        private ICommand showCommand;
        public ICommand ShowCommand
        {
            get
            {
                if (this.showCommand is null)
                {
                    this.showCommand = new RelayCommand(
                        (param) =>
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
                        },
                        (param) =>
                        {
                            if (FakePass.Text == string.Empty)
                                return true;
                            else
                                return true;
                        });
                }
                return this.showCommand;
            }
        }

        private ICommand hintCommand;
        public ICommand HintCommand
        {
            get
            {
                if (hintCommand is null)
                {
                    hintCommand = new RelayCommand(
                        (param) =>
                        {
                            PassBox.Visibility = Visibility.Visible;
                            FakePass.Visibility = Visibility.Collapsed;

                        }, null);
                }
                return hintCommand;
            }
        }

    }
}
