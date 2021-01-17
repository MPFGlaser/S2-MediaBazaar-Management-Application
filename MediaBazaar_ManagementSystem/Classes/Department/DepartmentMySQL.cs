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
                ErrorMessages.Generic(ex);
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
                ErrorMessages.Generic(ex);
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
                ErrorMessages.Generic(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<(int shiftId, int departmentId, int capacity)> GetCapacityForAllDepartments()
        {
            List<(int shiftId, int departmentId, int capacity)> allDepartmentCapacities = new List<(int shiftId, int departmentId, int capacity)>();
            String query = "SELECT * FROM capacity_per_department";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allDepartmentCapacities.Add((Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2])));
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

            return allDepartmentCapacities;
        }

        public List<(int shiftId, int departmentId, int capacity)> GetCapacityForDepartmentsInCertainShifts(List<int> shiftIds)
        {
            List<(int shiftId, int departmentId, int capacity)> departmentInfo = new List<(int shiftId, int departmentId, int capacity)>();
            String query = "SELECT * FROM capacity_per_department";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (shiftIds.Contains(Convert.ToInt32(reader[0])))
                    {
                        departmentInfo.Add((Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2])));
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


            return departmentInfo;
        }

        public void UpdateCapacityForDepartmentList(List<(int shiftId, int departmentId, int capacity)> toUpdate)
        {
            try
            {
                connection.Open();
                foreach ((int shiftId, int departmentId, int capacity) data in toUpdate)
                {
                    String query = "UPDATE capacity_per_department SET capacity = @capacity WHERE shiftId = @shiftId AND departmentId = @departmentId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@shiftId", data.shiftId);
                    command.Parameters.AddWithValue("@departmentId", data.departmentId);
                    command.Parameters.AddWithValue("@capacity", data.capacity);
                    command.ExecuteNonQuery();
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
        }

    }
}
