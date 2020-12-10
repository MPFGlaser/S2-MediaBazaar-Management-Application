using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Creates a function in the database with the given name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public bool Create(string name)
        {
            bool success = false;
            int rowsAffected = 0;
            String query = "INSERT INTO functions (function) VALUES (@function)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@function", name);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.Generic(ex);
                success = false;
            }
            finally
            {
                connection.Close();
            }
            return success;
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

        /// <summary>
        /// Updates the specified function with its new permissions.
        /// </summary>
        /// <param name="functionId">The function identifier.</param>
        /// <param name="Dictionary`2">The permisssions</param>
        /// <returns></returns>
        public bool Update(int functionId, Dictionary<string, bool> permissions)
        {
            string querySet = null;

            foreach (KeyValuePair<string, bool> i in permissions)
            {
                querySet += i.Key + " = " + Convert.ToInt32(i.Value) + ", ";
            }

            querySet = querySet.Remove(querySet.Length - 2, 1);

            bool success = false;
            int rowsAffected = 0;
            String query = $"UPDATE functions SET {querySet}WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", functionId);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.Generic(ex);
                success = false;
            }
            finally
            {
                connection.Close();
            }
            return success;
        }
    }
}
