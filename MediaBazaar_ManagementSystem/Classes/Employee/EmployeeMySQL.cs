using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            String query = "INSERT INTO employees VALUES (@id, @active, @firstName, @surName, @username, @picture, @password, @phoneNumber, @address, @city, @postalcode, @emailAddress, @dateOfBirth, @spouseName, @spousePhoneNumber, @bsn, @functions, @preferredShift, @workingDepartments, @contractHours)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", employee.Id);
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
            command.Parameters.AddWithValue("@functions", 1337);
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
                    function = Convert.ToInt32(reader["functions"]);
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

            String working_employees = "SELECT * FROM working_employees";
            MySqlCommand working_employeesCommand = new MySqlCommand(working_employees, connection);

            try
            {
                connection.Open();
                MySqlDataReader working_employeesReader = working_employeesCommand.ExecuteReader();

                while (working_employeesReader.Read())
                {
                    if (weekShiftIds.Contains(Convert.ToInt32(working_employeesReader[0])))
                    {
                        foreach (Employee e in allEmployees)
                        {
                            while (working_employeesReader.Read())
                            {
                                if (Convert.ToInt32(working_employeesReader[1]) == e.Id)
                                {
                                    e.WorkingHours += 4.5f;
                                    Console.WriteLine("e.WorkingHours: " + e.WorkingHours);
                                }
                            }
                        }
                    }
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
    }
}

/*foreach(Employee e in allEmployees)
                {
                    foreach (int shiftId in weekShiftIds)
                    {
                        String employeeIds = "SELECT employeeId FROM working_employees WHERE shiftId = @shiftId";
                        MySqlCommand employeeIdsCommand = new MySqlCommand(employeeIds, connection);
                        employeeIdsCommand.Parameters.AddWithValue("@shiftId", shiftId);

                        MySqlDataReader employeeIdsReader = employeeIdsCommand.ExecuteReader();
                        while (employeeIdsReader.Read())
                        {
                            if (Convert.ToInt32(employeeIdsReader[0]) == e.Id)
                            {
                                e.WorkingHours += 4.5f;
                            }
                        }
                        employeeIdsReader.Close();
                    }
                }*/
