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

namespace Gestor_Cuentas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void CambioTab(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                TabControl tabControl = (TabControl)e.Source;
                if (tabControl.SelectedItem == tabEmp)
                {
                    this.Width = 1100;
                    this.Height = 800;
                }
                else if (tabControl.SelectedItem == tabAlumn)
                {
                    this.Width = 800;
                    this.Height = 600;
                }
                else if (tabControl.SelectedItem == tabTutores)
                {
                    this.Width = 800;
                    this.Height = 600;
                }
                else if (tabControl.SelectedItem == tabAsig)
                {
                    this.Width = 800;
                    this.Height = 500;
                }
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            gridDatosEmpresa.Visibility = Visibility.Visible;

            gridTablaEmpresa.Visibility = Visibility.Hidden;
        }

        private void btModiEmp_Copy_Click(object sender, RoutedEventArgs e)
        {
            gridDatosEmpresa.Visibility = Visibility.Hidden;

            gridTablaEmpresa.Visibility = Visibility.Visible;
        }
    }
}
