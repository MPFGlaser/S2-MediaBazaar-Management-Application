using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem
{
    public class FunctionMySQL : IFunctionStorage
    {
        MySqlConnection connection;
        string connectionString;

        public FunctionMySQL()
        {
            connectionString = ConnectionString.Read();
            connection = new MySqlConnection(connectionString);
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the functions from the database and stores them in a dictionary with their id as the key.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetFunctions()
        {
            Dictionary<int, string> functions = new Dictionary<int, string>();
            string sql = "SELECT * FROM functions;";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                connection.Open();

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    functions.Add(Convert.ToInt32(rdr.GetString("id")), rdr.GetString("function"));
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.Generic(ex);
            }
            finally
            {
                connection.Close();
            }
            return functions;
        }

        /// <summary>
        /// Gets the permissions associated with the function id supplied.
        /// </summary>
        /// <param name="function">The function.</param>
        /// <returns></returns>
        public List<string> GetPermissions(int function)
        {
            List<string> output = new List<string>();

            String query = "SELECT * FROM functions WHERE id = @functionId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@functionId", function);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string name = reader.GetName(i);
                        if (name != "id" && name != "function")
                        {
                            bool value = Convert.ToBoolean(reader.GetValue(i));
                            if (value == true)
                            {
                                output.Add(name);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.Generic(ex);
            }
            finally
            {
                connection.Close();
            }

            return output;
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}
