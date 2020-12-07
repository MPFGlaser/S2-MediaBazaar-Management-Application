using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    class EmployeeMySQL : IEmployeeStorage
    {
        MySqlConnection connection;
        string connectionString;

        public EmployeeMySQL()
        {
            connectionString = ConnectionString.Read();
            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Function to update an employee in the databse.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Whether the creation was successful.</returns>
        public bool Create(Employee employee)
        {
            bool success = false;
            int rowsAffected = 0;
            String query = "INSERT INTO employees (active, firstName, surName, username, picture, password, phoneNumber, address, city, postalcode, emailAddress, dateOfBirth, spouseName, spousePhoneNumber, bsn, preferredShift, workingDepartments, contractHours, functions) VALUES (@active, @firstName, @surName, @username, @picture, @password, @phoneNumber, @address, @city, @postalcode, @emailAddress, @dateOfBirth, @spouseName, @spousePhoneNumber, @bsn, @preferredShift, @workingDepartments, @contractHours, @functions)";
            MySqlCommand command = new MySqlCommand(query, connection);
            //command.Parameters.AddWithValue("@id", employee.Id);
            command.Parameters.AddWithValue("@active", employee.Active);
            command.Parameters.AddWithValue("@firstName", employee.FirstName);
            command.Parameters.AddWithValue("@surName", employee.SurName);
            command.Parameters.AddWithValue("@username", employee.UserName);
            command.Parameters.AddWithValue("@picture", "TempPicture"); //TEMP HAS TO CHANGE
            command.Parameters.AddWithValue("@password", Encrypt.Run(employee.Password));
            command.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
            command.Parameters.AddWithValue("@address", employee.Address);
            command.Parameters.AddWithValue("@city", employee.City);
            command.Parameters.AddWithValue("@postalcode", employee.PostalCode);
            command.Parameters.AddWithValue("@emailAddress", employee.Email);
            command.Parameters.AddWithValue("@dateOfBirth", employee.DateOfBirth);
            command.Parameters.AddWithValue("@spouseName", employee.SpouseName);
            command.Parameters.AddWithValue("@spousePhoneNumber", employee.SpousePhone);
            command.Parameters.AddWithValue("@bsn", employee.Bsn);
            command.Parameters.AddWithValue("@preferredShift", employee.PreferredHours);
            command.Parameters.AddWithValue("@workingDepartments", employee.WorkingDepartments);
            command.Parameters.AddWithValue("@contractHours", employee.ContractHours);
            command.Parameters.AddWithValue("@functions", employee.Function);

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
        /// Function to get information from the database about an employee with a certain id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An instance of Employee with all data found in the database relating to the employee with the entered id.</returns>
        public Employee Get(int id)
        {
            Employee output = null;

            String query = "SELECT id, active, firstName, surName, username, emailAddress, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhoneNumber, functions, postalcode, city, preferredShift, workingDepartments, contractHours FROM employees WHERE id = @employeeId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@employeeId", id);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    output = new Employee(Convert.ToInt32(reader[0]), (bool)reader[1], reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), "", reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), Convert.ToDateTime(reader[8]), Convert.ToInt32(reader[9]), reader[10].ToString(), reader[11].ToString(), Convert.ToInt32(reader[12]), reader[13].ToString(), reader[14].ToString(), reader[15].ToString(), reader[16].ToString(), Convert.ToInt32(reader[17]));
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
        /// A function to get a list of employees from the database.
        /// </summary>
        /// <returns>A list of Employee objects containing all employees found in the database.</returns>
        public List<Employee> GetAll(bool activeOnly)
        {
            List<Employee> output = new List<Employee>();
            String query = "SELECT * FROM employees";
            if (activeOnly)
            {
                query += " WHERE active = 1";
            }

            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                int id, bsn, function, contractHours;
                bool active;
                string firstName, surName, userName, password, email, phoneNumber, address, spouseName, spousePhone, postalCode, city, preferredShift, workingDepartments;
                DateTime dateOfBirth;

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"]);
                    active = Convert.ToBoolean(reader["active"]);
                    firstName = Convert.ToString(reader["firstName"]);
                    surName = Convert.ToString(reader["surName"]);
                    userName = Convert.ToString(reader["username"]);
                    password = Convert.ToString(reader["password"]);
                    phoneNumber = Convert.ToString(reader["phoneNumber"]);
                    address = Convert.ToString(reader["address"]);
                    email = Convert.ToString(reader["emailAddress"]);
                    dateOfBirth = Convert.ToDateTime(reader["dateOfBirth"]);
                    spouseName = Convert.ToString(reader["spouseName"]);
                    spousePhone = Convert.ToString(reader["spousePhoneNUmber"]);
                    bsn = Convert.ToInt32(reader["bsn"]);
                    if (!reader.IsDBNull(reader.GetOrdinal("functions"))) function = Convert.ToInt32(reader["functions"]);
                    else function = 0;
                    postalCode = Convert.ToString(reader["postalcode"]);
                    city = Convert.ToString(reader["city"]);
                    preferredShift = Convert.ToString(reader["preferredShift"]);
                    workingDepartments = Convert.ToString(reader["workingDepartments"]);
                    contractHours = Convert.ToInt32(reader["contractHours"]);

                    Employee emp = new Employee(id, active, firstName, surName, userName, password, email, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhone, function, postalCode, city, preferredShift, workingDepartments, contractHours);
                    output.Add(emp);
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.RetrieveEmployee(ex);
            }
            finally
            {
                connection.Close();
            }

            return output;
        }

        /// <summary>
        /// Function to update an employee in the database.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Whether the update was successful.</returns>
        public bool Update(Employee employee)
        {
            bool success = false;
            int rowsAffected = 0;
            String query = "UPDATE employees SET active = @active, firstName = @firstName, surName = @surName, username = @username, picture = @picture, phoneNumber = @phoneNumber, address = @address, city = @city, postalcode = @postalcode, emailAddress = @emailAddress, dateOfBirth = @dateOfBirth, spouseName = @spouseName, spousePhoneNumber = @spousePhoneNumber, bsn = @bsn, functions = @function, preferredShift = @preferredShift, workingDepartments = @workingDepartments, contractHours = @contractHours WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@active", employee.Active);
            command.Parameters.AddWithValue("@id", employee.Id);
            command.Parameters.AddWithValue("@firstName", employee.FirstName);
            command.Parameters.AddWithValue("@surName", employee.SurName);
            command.Parameters.AddWithValue("@username", employee.UserName);
            command.Parameters.AddWithValue("@picture", "TempPicture"); //TEMP HAS TO CHANGE
            command.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
            command.Parameters.AddWithValue("@address", employee.Address);
            command.Parameters.AddWithValue("@city", employee.City);
            command.Parameters.AddWithValue("@postalcode", employee.PostalCode);
            command.Parameters.AddWithValue("@emailAddress", employee.Email);
            command.Parameters.AddWithValue("@dateOfBirth", employee.DateOfBirth);
            command.Parameters.AddWithValue("@spouseName", employee.SpouseName);
            command.Parameters.AddWithValue("@spousePhoneNumber", employee.SpousePhone);
            command.Parameters.AddWithValue("@bsn", employee.Bsn);
            command.Parameters.AddWithValue("@function", employee.Function);
            command.Parameters.AddWithValue("@preferredShift", employee.PreferredHours);
            command.Parameters.AddWithValue("@workingDepartments", employee.WorkingDepartments);
            command.Parameters.AddWithValue("@contractHours", employee.ContractHours);

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
        /// Returns the amount of hours an employee is scheduled within a certain week.
        /// </summary>
        public List<Employee> GetHoursWorked(List<Employee> allEmployees, DateTime monday, DateTime sunday)
        {
            List<int> weekShiftIds = GetShiftIdsInWeek(monday, sunday);
            List<EmployeeShift> employeeShifts = new List<EmployeeShift>();
            int index = 0;

            String working_employees = "SELECT shiftId, employeeId FROM working_employees";
            MySqlCommand working_employeesCommand = new MySqlCommand(working_employees, connection);

            try
            {
                connection.Open();
                MySqlDataReader working_employeesReader = working_employeesCommand.ExecuteReader();

                while (working_employeesReader.Read())
                {
                    employeeShifts.Add(new EmployeeShift(Convert.ToInt32(working_employeesReader[0]), Convert.ToInt32(working_employeesReader[1])));
                }

                working_employeesReader.Close();
            }
            catch (Exception ex)
            {
                ErrorMessages.Shift(ex);
            }
            finally
            {
                connection.Close();
            }

            foreach(EmployeeShift es in employeeShifts)
            {
                if (weekShiftIds.Contains(es.ShiftId))
                {
                    foreach (Employee e in allEmployees)
                    {
                        if (es.EmployeeId == e.Id)
                        {
                            e.WorkingHours += Globals.shiftDuration;
                        }
                    }
                }
            }

            return allEmployees;
        }

        public List<int> GetShiftIdsInWeek(DateTime monday, DateTime sunday)
        {
            List<int> weekShiftIds = new List<int>();
            string mondaySql = monday.ToString("yyyy-MM-dd");
            string sundaySql = sunday.ToString("yyyy-MM-dd");

            String query = "SELECT id FROM shifts WHERE date >= @dateMonday AND date <= @dateSunday";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@dateMonday", mondaySql);
            command.Parameters.AddWithValue("@dateSunday", sundaySql);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    weekShiftIds.Add(Convert.ToInt32(reader[0]));
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

            return weekShiftIds;
        }

        /// <summary>
        /// Function to create table functions in the database.
        /// </summary>
        //public void CheckFunctions()
        //{
        //    string query = "CREATE TABLE `functions` (`id` int(2) NOT NULL, `function` varchar(20) NOT NULL) ENGINE=InnoDB DEFAULT CHARSET=utf8;";
        //    MySqlCommand command = new MySqlCommand(query, connection);
        //    try
        //    {
        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {

        //        return;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    query = "ALTER TABLE `functions` ADD PRIMARY KEY (`id`);";
        //    command = new MySqlCommand(query, connection);
        //    try
        //    {
        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMessages.Generic(ex);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    query = "INSERT INTO functions  VALUES  (0,'New Employee'), (1,'Depot worker'), (2,'Sales representative'),  (3,'Manager'), (4,'Cashier'), (5,'Human resources');";
        //    command = new MySqlCommand(query, connection);
        //    try
        //    {
        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMessages.Generic(ex);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}
        /// <summary>
        /// Function to create table functions in the database.
        /// </summary>
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
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        string name = reader.GetName(i);
                        if (name != "id" && name != "function")
                        {
                            bool value = Convert.ToBoolean(reader.GetValue(i));
                            if(value == true)
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
    }
}