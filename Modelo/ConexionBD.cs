using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;


namespace Modelo
{
    public class ConexionBD
    {
        private string cadena = "server=127.0.0.1; database=db_empresa; user=root; password=root; Port=3307";
        public MySqlConnection conectar = new MySqlConnection();

        public void AbrirConexion(){

            try
            {
                //conectar = new MySqlConnection(); ya no se instancia
                conectar.ConnectionString = cadena;
                conectar.Open();

               // System.Diagnostics.Debug.WriteLine("Conexion Exitosa");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //System.Diagnostics.Debug.WriteLine(ex.Message);

            }

        }
        public void CerrarConexion(){
            try
            {
                if (conectar.State == ConnectionState.Open)
                {
                    conectar.Close();
                    System.Diagnostics.Debug.WriteLine("Cerrar Conexion");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}