using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public class ShiftMySQL : IShiftStorage
    {
        MySqlConnection connection;
        string connectionString;
        IEmployeeStorage employeeStorage;

        public ShiftMySQL()
        {
            connectionString = ConnectionString.Read();
            connection = new MySqlConnection(connectionString);
            employeeStorage = new EmployeeMySQL();
        }

        /// <summary>
        /// Assigns an employeeId to a shiftId with a departmentId.
        /// </summary>
        /// <param name="shiftId">The shift identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>Whether or not the shift assignation was successful.</returns>
        public bool Assign(int shiftId, int employeeId, int departmentId)
        {
            bool success = false;
            int rowsAffected = 0;

            String query = "INSERT INTO working_employees VALUES ((SELECT id FROM shifts where id = @shiftId), @employeeId, @departmentId)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shiftId", shiftId);
            command.Parameters.AddWithValue("@employeeId", employeeId);
            command.Parameters.AddWithValue("@departmentId", departmentId);

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
                success = false;
                ErrorMessages.Generic(ex);
            }
            finally
            {
                connection.Close();
            }
            return success;
        }

        /// <summary>
        /// Clears the specified shift identifier from the database to prevent duplicate shifts.
        /// </summary>
        /// <param name="shiftId">The shift identifier.</param>
        /// <returns>Whether or not the clear action was successfully carried out.</returns>
        public bool Clear(int shiftId)
        {
            bool success = false;
            int rowsAffected = 0;

            String query = "DELETE FROM working_employees WHERE shiftId = @shiftId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shiftId", shiftId);

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
                success = false;
                ErrorMessages.Generic(ex);
            }
            finally
            {
                connection.Close();
            }

            return success;
        }

        /// <summary>
        /// Creates a shift in the database.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The shiftId.</returns>
        public int Create(Shift input)
        {
            int output = 0;
            String query = ("INSERT INTO shifts VALUES (@id, @date, @shiftType); SELECT LAST_INSERT_ID()");
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", input.Id);
            command.Parameters.AddWithValue("@date", input.Date);
            command.Parameters.AddWithValue("@shiftType", input.ShiftTime);

            try
            {
                connection.Open();
                output = Convert.ToInt32(command.ExecuteScalar());
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
        /// Checks if a shift exists with the specified date and time.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="time">The time.</param>
        /// <returns>The shiftId, if one is found.</returns>
        public int Exists(DateTime date, ShiftTime time)
        {
            int output = 0;
            String sql = "SELECT id FROM shifts WHERE date = @date AND shiftType = @shiftType";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@shiftType", time);

            try
            {
                connection.Open();
                output = Convert.ToInt32(command.ExecuteScalar());
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
        /// Gets information of a shift based on the specified date and time.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="time">The time.</param>
        /// <returns>The shift found.</returns>
        public Shift Get(DateTime date, ShiftTime time)
        {
            Shift output = null;
            string dateSql = date.ToString("yyyy-MM-dd HH:mm:ss");
            String sql = "SELECT count(*) FROM shifts WHERE date = @date AND shiftType = @shiftType";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@date", dateSql);
            command.Parameters.AddWithValue("@shiftType", time);

            try
            {
                connection.Open();
                int shiftExists = Convert.ToInt32(command.ExecuteScalar());
                if (shiftExists != 0)
                {
                    String sql1 = "SELECT id FROM shifts WHERE date = @date AND shiftType = @shiftType";
                    MySqlCommand command1 = new MySqlCommand(sql1, connection);
                    command1.Parameters.AddWithValue("@date", dateSql);
                    command1.Parameters.AddWithValue("@shiftType", time);
                    MySqlDataReader reader = command1.ExecuteReader();
                    while (reader.Read())
                    {
                        output = new Shift(Convert.ToInt32(reader[0]), date, time);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.Shift(ex);
            }
            finally
            {
                connection.Close();
            }

            return output;
        }

        /// <summary>
        /// Gets a list of employees within a specified department working the specified shift.
        /// </summary>
        /// <param name="shiftId">The shift identifier.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>A list of employees within one department that works the specified shift.</returns>
        public List<Employee> GetDepartmentEmployees(int shiftId, int departmentId)
        {
            List<int> employeeIds = new List<int>();
            List<Employee> output = new List<Employee>();

            String query = "SELECT employeeId FROM working_employees WHERE departmentId = @departmentId AND shiftId = @shiftId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentId", departmentId);
            command.Parameters.AddWithValue("@shiftId", shiftId);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employeeIds.Add(Convert.ToInt32(reader[0]));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                ErrorMessages.RetrieveEmployee(ex);
            }
            finally
            {
                connection.Close();

                foreach (int id in employeeIds)
                {
                    output.Add(employeeStorage.Get(id));
                }
            }

            return output;
        }

        /// <summary>
        /// Gets the employees working on a shift.
        /// </summary>
        /// <param name="shiftId">The shift identifier.</param>
        /// <returns>A list of employees working the specified shift.</returns>
        public List<Employee> GetEmployees(int shiftId)
        {
            List<Employee> output = new List<Employee>();
            List<int> shiftEmployeeIds = new List<int>();
            String query = "SELECT count(*) FROM working_employees WHERE shiftId = @shiftId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shiftId", shiftId);

            try
            {
                connection.Open();
                int shiftHasEmployees = Convert.ToInt32(command.ExecuteScalar());
                if (shiftHasEmployees > 0)
                {
                    String query2 = "SELECT employeeId FROM working_employees WHERE shiftId = @shiftId";
                    MySqlCommand command2 = new MySqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@shiftId", shiftId);
                    MySqlDataReader reader = command2.ExecuteReader();
                    while (reader.Read())
                    {
                        shiftEmployeeIds.Add(Convert.ToInt32(reader[0]));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.Shift(ex);
            }
            finally
            {
                connection.Close();
            }

            foreach (int i in shiftEmployeeIds)
            {
                output.Add(employeeStorage.Get(i));
            }

            return output;
        }

        /// <summary>
        /// Gets the occupation of a specified shift.
        /// </summary>
        /// <param name="shiftId">The shift identifier.</param>
        /// <returns>The occupation of a shift as an integer.</returns>
        public int GetOccupation(int shiftId)
        {
            int output = 0;

            String query = "SELECT COUNT(shiftId) FROM working_employees WHERE shiftId = @shiftId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shiftId", shiftId);

            try
            {
                connection.Open();
                output = Convert.ToInt32(command.ExecuteScalar());
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
        /// Gets a list of shifts occurring between the two specified dates.
        /// </summary>
        /// <param name="monday">The monday.</param>
        /// <param name="sunday">The sunday.</param>
        /// <returns>A list of shifts</returns>
        public List<Shift> GetWeek(DateTime monday, DateTime sunday)
        {
            List<Shift> weekShifts = new List<Shift>();
            Shift temp;
            List<int> workingEmployeeIds;

            string mondaySql = monday.ToString("yyyy-MM-dd");
            string sundaySql = sunday.ToString("yyyy-MM-dd");

            String query = "SELECT * FROM shifts WHERE date >= @dateMonday AND date <= @dateSunday";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@dateMonday", mondaySql);
            command.Parameters.AddWithValue("@dateSunday", sundaySql);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    temp = new Shift(Convert.ToInt32(reader[0]), (DateTime)reader[1], (ShiftTime)reader[2]);
                    weekShifts.Add(temp);
                }

                reader.Close();

                foreach (Shift s in weekShifts)
                {
                    workingEmployeeIds = new List<int>();

                    String getEmployeesQuery = "SELECT employeeId FROM working_employees WHERE shiftId = @shiftId";
                    MySqlCommand getEmployeesCommand = new MySqlCommand(getEmployeesQuery, connection);
                    getEmployeesCommand.Parameters.AddWithValue("@shiftId", s.Id);

                    MySqlDataReader getEmployeesReader = getEmployeesCommand.ExecuteReader();
                    while (getEmployeesReader.Read())
                    {
                        workingEmployeeIds.Add(Convert.ToInt32(getEmployeesReader[0]));
                    }

                    getEmployeesReader.Close();

                    s.EmployeeIds = workingEmployeeIds;
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.Shift(ex);
            }
            finally
            {
                connection.Close();
            }

            return weekShifts;
        }
    }
}
