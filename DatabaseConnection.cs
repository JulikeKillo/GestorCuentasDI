﻿using System;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Gestor_Cuentas
{
    public class DatabaseConnection : Connection
    {
        private MySqlConnection SqlConnection;
        private string ConnectionString;


        public DatabaseConnection()
        {
            ConnectionString = "server=" + server +
                "; port=" + port +
                "; database=" + database +
                "; user= " + user +
                "; password=" + password;
            SqlConnection = new MySqlConnection(ConnectionString);
        }

        public MySqlConnection getConnection()
        {
            try
            {
                if (SqlConnection.State != System.Data.ConnectionState.Open)
                {
                    SqlConnection.Open();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return SqlConnection;
        }

        public void closeConexion()
        {
            SqlConnection.Close();
        }
    }
}
