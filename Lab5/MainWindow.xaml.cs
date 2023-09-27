using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace WPFExecuteNonQuery
{
    public partial class MainWindow : Window
    {
        public static string connectionString = "Data Source=LAB1504-05\\SQLEXPRESS;Initial Catalog=Neptuno3;User ID=Will;Password=123456";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los valores de los cuadros de texto para clientes
            string idCliente = txtIdCliente.Text;
            string nombreCompania = txtNombreCompania.Text;
            string nombreContacto = txtNombreContacto.Text;
            string cargoContacto = txtCargoContacto.Text;
            string direccion = txtDireccion.Text;
            string ciudad = txtCiudad.Text;
            string region = txtRegion.Text;
            string codPostal = txtCodPostal.Text;
            string pais = txtPais.Text;
            string telefono = txtTelefono.Text;
            string fax = txtFax.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Llamar al procedimiento almacenado InsertarCliente
                    using (SqlCommand command = new SqlCommand("InsertarClientes", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al procedimiento almacenado
                        command.Parameters.AddWithValue("@IdCliente", idCliente);
                        command.Parameters.AddWithValue("@NombreCompania", nombreCompania);
                        command.Parameters.AddWithValue("@NombreContacto", nombreContacto);
                        command.Parameters.AddWithValue("@CargoContacto", cargoContacto);
                        command.Parameters.AddWithValue("@Direccion", direccion);
                        command.Parameters.AddWithValue("@Ciudad", ciudad);
                        command.Parameters.AddWithValue("@Region", region);
                        command.Parameters.AddWithValue("@CodPostal", codPostal);
                        command.Parameters.AddWithValue("@Pais", pais);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.Parameters.AddWithValue("@Fax", fax);

                        // Ejecutar el procedimiento almacenado
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Datos del cliente guardados exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar los datos del cliente.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}