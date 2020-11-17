using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public class DepartmentMySQL : IDepartmentStorage
    {
        MySqlConnection connection;
        string connectionString;

        public DepartmentMySQL()
        {
            connectionString = ConnectionString.Read();
            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Creates a new department in the database with the given name.
        /// </summary>
        /// <param name="name">The name.</param>
        public void Create(string name)
        {
            String query = "INSERT INTO departments (departmentName) VALUES (@departmentName)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentName", name);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Gets a list of all departments from the database.
        /// </summary>
        /// <returns>A list of all departments.</returns>
        public List<Department> GetAll()
        {
            List<Department> allDepartments = new List<Department>();
            String query = "SELECT * FROM departments";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allDepartments.Add(new Department(Convert.ToInt32(reader[0]), reader[1].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return allDepartments;
        }

        /// <summary>
        /// Removes a department with the given id from the database.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Remove(int id)
        {
            String query = "DELETE FROM departments WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
