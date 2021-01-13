using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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
            String query = ("INSERT INTO shifts VALUES (@id, @date, @shiftType, @capacity); SELECT LAST_INSERT_ID()");
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", input.Id);
            command.Parameters.AddWithValue("@date", input.Date);
            command.Parameters.AddWithValue("@shiftType", input.ShiftTime);
            command.Parameters.AddWithValue("@capacity", input.Capacity);

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
            int shifttype = 0;
            string dateSql = date.ToString("yyyy-MM-dd HH:mm:ss");
            String sql = "SELECT count(*) FROM shifts WHERE date = @date AND shiftType = @shiftType";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@date", dateSql);
            switch (time)
            {
                case ShiftTime.Morning:
                    shifttype = 0;
                    break;
                case ShiftTime.Afternoon:
                    shifttype = 1;
                    break;
                case ShiftTime.Evening:
                    shifttype = 2;
                    break;
                default:
                    break;
            }
            command.Parameters.AddWithValue("@shiftType", shifttype);

            try
            {
                connection.Open();
                int shiftExists = Convert.ToInt32(command.ExecuteScalar());
                if (shiftExists != 0)
                {
                    String sql1 = "SELECT id, capacity FROM shifts WHERE date = @date AND shiftType = @shiftType";
                    MySqlCommand command1 = new MySqlCommand(sql1, connection);
                    command1.Parameters.AddWithValue("@date", dateSql);
                    command1.Parameters.AddWithValue("@shiftType", shifttype);
                    MySqlDataReader reader = command1.ExecuteReader();
                    while (reader.Read())
                    {
                        output = new Shift(Convert.ToInt32(reader[0]), date, time, Convert.ToInt32(reader[1]));
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
        /// Gets information of a shift based on the specified employee and date.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="date">The date.</param>
        /// <returns>The shift found.</returns>
        public List<Shift> GetShiftsByEmployee(int id, string date)
        {
            List<Shift> allshifts = new List<Shift>();
            List<Shift> outputs = new List<Shift>();
            string query = "SELECT id, date, shiftType, capacity FROM shifts WHERE date=@date ORDER BY shiftType ASC;";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@date", date);
                MySqlDataReader reader = cmd.ExecuteReader();
                Shift shift = null;
                while (reader.Read())
                {
                    int shiftid = Convert.ToInt32(reader[0]);
                    DateTime shiftdate = Convert.ToDateTime(reader[1]);
                    int shifttype = Convert.ToInt32(reader[2]);
                    int capacity = Convert.ToInt32(reader[3]);
                    switch (shifttype)
                    {
                        case 0:
                            shift = new Shift(shiftid, shiftdate, ShiftTime.Morning, capacity);
                            allshifts.Add(shift);
                            break;
                        case 1:
                            shift = new Shift(shiftid, shiftdate, ShiftTime.Afternoon, capacity);
                            allshifts.Add(shift);
                            break;
                        case 2:
                            shift = new Shift(shiftid, shiftdate, ShiftTime.Evening, capacity);
                            allshifts.Add(shift);
                            break;
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
            if (allshifts.Count > 0)
                foreach (Shift s in allshifts)
                {
                    string sql = "SELECT * FROM working_employees WHERE employeeId = @id AND shiftId=@shiftId;";
                    try
                    {
                        connection.Open();
                        MySqlCommand cmd2 = new MySqlCommand(sql, connection);
                        cmd2.Parameters.AddWithValue("@id", id);
                        cmd2.Parameters.AddWithValue("@shiftId", s.Id);
                        MySqlDataReader reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            outputs.Add(s);
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
                }
            return outputs;
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

        public bool AddCapacityForDepartment(int shiftId, int departmentId, int capacity)
        {
            bool success = false;
            int rowsAffected = 0;

            String query = "INSERT INTO capacity_per_department VALUES (@shiftId, @departmentId, @capacity)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shiftId", shiftId);
            command.Parameters.AddWithValue("@departmentId", departmentId);
            command.Parameters.AddWithValue("@capacity", capacity);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    success = true;
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
            return success;
        }

        public bool UpdateCapacityPerDepartment(int shiftId, int departmentId, int capacity)
        {
            bool success = false;
            int rowsAffected = 0;

            String query = "UPDATE capacity_per_department SET capacity = @capacity WHERE shiftId = @shiftId AND departmentId = @departmentId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shiftId", shiftId);
            command.Parameters.AddWithValue("@departmentId", departmentId);
            command.Parameters.AddWithValue("@capacity", capacity);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    success = true;
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
            return success;
        }

        public Dictionary<int, int> GetCapacityPerDepartment(int shiftId)
        {
            Dictionary<int, int> output = new Dictionary<int, int>();

            String query = "SELECT departmentId, capacity FROM capacity_per_department WHERE shiftId = @shiftId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shiftId", shiftId);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    output.Add(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]));
                }
                reader.Close();
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
                    temp = new Shift(Convert.ToInt32(reader[0]), (DateTime)reader[1], (ShiftTime)reader[2], Convert.ToInt32(reader[3]));
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

        public bool Update(Shift input)
        {
            bool success = false;
            int rowsAffected = 0;

            string dateSql = input.Date.ToString("yyyy-MM-dd");


            String query = "UPDATE shifts SET date = @date, shiftType = @shiftType, capacity = @capacity WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@date", dateSql);
            command.Parameters.AddWithValue("@shiftType", input.ShiftTime);
            command.Parameters.AddWithValue("@capacity", input.Capacity);
            command.Parameters.AddWithValue("@id", input.Id);

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
                throw;
            }
            finally
            {
                connection.Close();
            }
            return success;
        }

        public void CreateAttendance(int employeeId, int shiftId, string clockin)
        {
            string sql = "INSERT INTO employee_attendance (employeeid, shiftid, clockin) VALUES (@employeeId, @shiftId, @clockin);";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@employeeId", employeeId);
                command.Parameters.AddWithValue("@shiftId", shiftId);
                command.Parameters.AddWithValue("@clockin", clockin);
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                ErrorMessages.Shift(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void ModifyClockInAttendance(int attid, string clockin)
        {
            string sql = "UPDATE employee_attendance SET clockin = @clockin WHERE id = @attid;";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@clockin", clockin);
                command.Parameters.AddWithValue("@attid", attid);
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                ErrorMessages.Shift(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void ModifyClockOutAttendance(int attid, string clockout, int minutes)
        {
            string sql = "UPDATE employee_attendance SET clockout = @clockout, minutesworked = @minutes WHERE id = @attid;";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@clockout", clockout);
                command.Parameters.AddWithValue("@attid", attid);
                command.Parameters.AddWithValue("@minutes", minutes);
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                ErrorMessages.Shift(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public int CheckAttendance(int userid, int shiftId)
        {
            int appearance = 0;
            try
            {
                string sql = "SELECT id FROM employee_attendance WHERE employeeid = @employeeId AND shiftid = @shiftId;";
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@employeeId", userid);
                command.Parameters.AddWithValue("@shiftId", shiftId);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    appearance = Convert.ToInt32(reader[0]);
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
            return appearance;
        }

        public string GetClockInAttendance(int id)
        {
            string date = "";
            try
            {
                string sql = "SELECT clockin FROM employee_attendance WHERE id = @id;";
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    date = reader[0].ToString();
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
            return date;
        }
        public string GetClockOutAttendance(int id)
        {
            string date = "";
            try
            {
                string sql = "SELECT clockout FROM employee_attendance WHERE id = @id;";
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0] != null) date = reader[0].ToString();
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
            return date;
        }

        public List<int> GetAllShiftIds()
        {
            List<int> shiftIds = new List<int>();

            String query = "SELECT id FROM shifts";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    shiftIds.Add(Convert.ToInt32(reader[0]));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                ErrorMessages.Shift(ex);
            }
            finally
            {
                connection.Close();
            }
            return shiftIds;
        }

        /// <summary>
        /// Clears the specified shift identifier from the database to prevent duplicate shifts.
        /// </summary>
        /// <param name="shiftId">The shift identifier.</param>
        /// <returns>Whether or not the clear action was successfully carried out.</returns>
        public bool ClearDept(int shiftId, int departmentId)
        {
            bool success = false;
            int rowsAffected = 0;

            String query = "DELETE FROM working_employees WHERE shiftId = @shiftId AND departmentId = @departmentId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shiftId", shiftId);
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

        public void ScheduleAllEmployeesInList(List<WorkingEmployee> employeesToSchedule)
        {
            List<MySqlCommand> allCommands = new List<MySqlCommand>();

            foreach (WorkingEmployee we in employeesToSchedule)
            {
                String query = "INSERT INTO working_employees VALUES (@shiftId, @employeeId, @departmentId);";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@shiftId", we.ShiftId);
                command.Parameters.AddWithValue("@employeeId", we.EmployeeId);
                command.Parameters.AddWithValue("@departmentId", we.DepartmentId);

                allCommands.Add(command);
            }
            try
            {
                connection.Open();
                foreach (MySqlCommand command in allCommands)
                {
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

        public List<WorkingEmployee> GetEmployeesInDepartmentInShift(int shiftId, int departmentId)
        {
            List<WorkingEmployee> toReturn = new List<WorkingEmployee>();

            String query = "SELECT employeeId FROM working_employees WHERE shiftId = @shiftId AND departmentId = @departmentId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shiftId", shiftId);
            command.Parameters.AddWithValue("@departmentId", departmentId);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    toReturn.Add(new WorkingEmployee(shiftId, Convert.ToInt32(reader[0]), departmentId));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                ErrorMessages.Generic(ex);
            }
            finally
            {
                connection.Close();
            }

            return toReturn;
        }
    }
}
