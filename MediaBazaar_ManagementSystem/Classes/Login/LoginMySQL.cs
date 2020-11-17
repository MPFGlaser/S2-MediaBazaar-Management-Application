using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    class LoginMySQL : ILoginStorage
    {
        MySqlConnection connection;
        string connectionString;

        public LoginMySQL()
        {
            connectionString = ConnectionString.Read();
            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Checks if the given username/password combination is found in the database.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The userId if one is found with the given credentials.</returns>
        public int Check(string username, string password)
        {
            int output = -1;

            String query = "SELECT id FROM employees WHERE username = @username AND password = @password";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", Encrypt.Run(password));

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    output = Convert.ToInt32(reader[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMessages.fileNotFound + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return output;
        }
    }
}
