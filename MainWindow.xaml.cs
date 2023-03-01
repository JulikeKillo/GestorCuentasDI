using System;
using System.Collections.Generic;
using System.Data;
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
using MySqlConnector;

namespace Gestor_Cuentas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AlumnoCrud alumnoCrud;
        public MainWindow()
        {
            InitializeComponent();
            alumnoCrud = new AlumnoCrud();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Cargar los datos de la tabla Alumno en el DataGrid
            tablaAlumno.ItemsSource = alumnoCrud.GetAllAlumnosAsDataTable().DefaultView;
        }
     
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

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

        private void limpiaCamposAlumno()
        {
            txfCodAlumno.Text = "";
            txfDniAlumno.Text = "";
            txfNombreAlumno.Text = "";
            txfApellidosAlumno.Text = "";
            dpFechaNacAlumno.SelectedDate = null;
        }
        private void btInsertAlumn_Click(object sender, RoutedEventArgs e)
        {
            int idAlumno = int.Parse(txfCodAlumno.Text);
            string dni = txfDniAlumno.Text;
            string nombre = txfNombreAlumno.Text;
            string apellido = txfApellidosAlumno.Text;
            DateTime fechaNacimiento = dpFechaNacAlumno.SelectedDate.Value;
            Alumno alumno = new Alumno(idAlumno, dni, nombre, apellido, fechaNacimiento);
            alumnoCrud.InsertAlumno(alumno);
            MessageBox.Show("Alumno insertado correctamente");
            tablaAlumno.ItemsSource = alumnoCrud.GetAllAlumnosAsDataTable().DefaultView;

            limpiaCamposAlumno();

            
        }

        private void btModiAlumn_Click(object sender, RoutedEventArgs e)
        {
            int idAlumno = int.Parse(txfCodAlumno.Text);
            string dni = txfDniAlumno.Text;
            string nombre = txfNombreAlumno.Text;
            string apellido = txfApellidosAlumno.Text;
            DateTime fechaNacimiento = dpFechaNacAlumno.SelectedDate.Value;
            Alumno alumno = new Alumno(idAlumno, dni, nombre, apellido, fechaNacimiento);
            alumnoCrud.UpdateAlumno(alumno);
            MessageBox.Show("Alumno actualizado correctamente");
            tablaAlumno.ItemsSource = alumnoCrud.GetAllAlumnosAsDataTable().DefaultView;
            limpiaCamposAlumno();

        }

        private void btElimAlumn_Click(object sender, RoutedEventArgs e)
        {
            int idAlumno = int.Parse(txfCodAlumno.Text);
            alumnoCrud.DeleteAlumno(idAlumno);
            MessageBox.Show("Alumno eliminado correctamente");
            tablaAlumno.ItemsSource = alumnoCrud.GetAllAlumnosAsDataTable().DefaultView;
            limpiaCamposAlumno();

        }

        private void tablaAlumno_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            // Obtenemos la fila seleccionada del DataGrid
            DataRowView rowView = tablaAlumno.SelectedItem as DataRowView;

            // Comprobamos que se ha seleccionado alguna fila
            if (rowView != null)
            {
                // Obtenemos los valores de las celdas de la fila seleccionada
                int idAlumno = (int)rowView["idalumno"];
                string dni = (string)rowView["dni"];
                string nombre = (string)rowView["nombre"];
                string apellido = (string)rowView["apellido"];
                DateTime fechaNacimiento = (DateTime)rowView["fechaNacimiento"];

                // Actualizamos los valores de los TextBox con los valores obtenidos
                txfCodAlumno.Text = idAlumno.ToString();
                txfDniAlumno.Text = dni;
                txfNombreAlumno.Text = nombre;
                txfApellidosAlumno.Text = apellido;
                dpFechaNacAlumno.SelectedDate = fechaNacimiento;
            }
        }
    }
}
