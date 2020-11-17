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
        }

        /// <summary>
        /// Function to update an employee in the database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool CreateEmployee(Employee employee)
        {
            bool succesfulExecution = false;
            int rowsAffected = 0;
            String query = "INSERT INTO employees VALUES (@id, @active, @firstName, @surName, @username, @picture, @password, @phoneNumber, @address, @city, @postalcode, @emailAddress, @dateOfBirth, @spouseName, @spousePhoneNumber, @bsn, @functions, @preferredShift)";
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

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    succesfulExecution = true;
                }
                else
                {
                    succesfulExecution = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
                succesfulExecution = false;
            }
            finally
            {
                connection.Close();
            }
            return succesfulExecution;
        }

        /// <summary>
        /// Function to get information from the database about an employee with a certain id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An instance of Employee with all data found in the database relating to the employee with the entered id</returns>
        public Employee GetEmployee(int id)
        {
            Employee output = null;

            String query = "SELECT id, active, firstName, surName, username, emailAddress, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhoneNumber, functions, postalcode, city, preferredShift FROM employees WHERE id = @employeeId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@employeeId", id);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    output = new Employee(Convert.ToInt32(reader[0]), (bool)reader[1], reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), "", reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), Convert.ToDateTime(reader[8]), Convert.ToInt32(reader[9]), reader[10].ToString(), reader[11].ToString(), Convert.ToInt32(reader[12]), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());
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

            return output;
        }

        /// <summary>
        /// A function to get a list of employees from the database
        /// </summary>
        /// <returns>A list of Employee objects containing all employees found in the database</returns>
        public List<Employee> GetEmployees(bool activeOnly)
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

                int id, bsn, function;
                bool active;
                string firstName, surName, userName, password, email, phoneNumber, address, spouseName, spousePhone, postalCode, city, preferredShift;
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

                    Employee emp = new Employee(id, active, firstName, surName, userName, password, email, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhone, function, postalCode, city, preferredShift);
                    output.Add(emp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employees.\n" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return output;
        }

        /// <summary>
        /// Function to update an employee in the database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool UpdateEmployee(Employee employee)
        {
            bool succesfulExecution = false;
            int rowsAffected = 0;
            String query = "UPDATE employees SET active = @active, firstName = @firstName, surName = @surName, username = @username, picture = @picture, phoneNumber = @phoneNumber, address = @address, city = @city, postalcode = @postalcode, emailAddress = @emailAddress, dateOfBirth = @dateOfBirth, spouseName = @spouseName, spousePhoneNumber = @spousePhoneNumber, bsn = @bsn, functions = @function, preferredShift = @preferredShift WHERE id = @id";
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

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    succesfulExecution = true;
                }
                else
                {
                    succesfulExecution = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
                succesfulExecution = false;
            }
            finally
            {
                connection.Close();
            }
            return succesfulExecution;
        }
    }
}
