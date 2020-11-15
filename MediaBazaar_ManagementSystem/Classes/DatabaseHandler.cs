using MediaBazaar_ManagementSystem.classes;
using MediaBazaar_ManagementSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace MediaBazaar_ManagementSystem.Classes
{
    /// <summary>
    /// Class to handle everything database-related
    /// </summary>
    public class DatabaseHandler
    {
        MySqlConnection conn;
        string connectionString;
        string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\connectionstringHome.cfg";

        public DatabaseHandler()
        {
            GetConnectionString();
            conn = new MySqlConnection(connectionString);
        }

        #region Database Connection
        /// <summary>
        /// Function to get the connection string from a config file
        /// </summary>
        public void GetConnectionString()
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                connectionString = sr.ReadToEnd();
            }
            catch (FileNotFoundException)
            {
                CreateConnectionStringFile();
                MessageBox.Show("No connection file found. Empty file has been created in application root directory.");
            }
            catch (IOException)
            {
                MessageBox.Show("Error reading file");
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        /// <summary>
        /// Function to create a new config file with default values 
        /// </summary>
        private void CreateConnectionStringFile()
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);

                sw.Write("server=localhost;database=name;uid=username;password=secret");
            }
            catch (IOException)
            {
                MessageBox.Show("Error creating file");
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
        #endregion

        #region User login
        /// <summary>
        /// Function to check if the entered login details match those found in the database
        /// <para>If they match, the user may be logged in</para>
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>An instance of Employee with all the data present in the database of the logged-in employee</returns>
        public Employee LoginUser(string username, string password)
        {
            Employee toReturn = null;

            // Prepares the SQL statement
            String sql = "SELECT count(*) FROM employees WHERE username = @username AND password = @password";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", SHA512(password));

            // Checks if the values entered correspond with those in the database
            try
            {
                conn.Open();
                int correctLogin = Convert.ToInt32(command.ExecuteScalar());
                if(correctLogin > 0)
                {
                    String sql2 = "SELECT id, active, firstName, surName, username, emailAddress, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhoneNumber, functions, postalcode, city, preferredShift FROM employees WHERE username = @username AND password = @password";
                    MySqlCommand command2 = new MySqlCommand(sql2, conn);
                    command2.Parameters.AddWithValue("@username", username);
                    command2.Parameters.AddWithValue("@password", SHA512(password));

                    try
                    {
                        MySqlDataReader reader = command2.ExecuteReader();
                        while (reader.Read())
                        {
                            toReturn = new Employee(Convert.ToInt32(reader[0]), (bool)reader[1], reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), "", reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), Convert.ToDateTime(reader[8]), Convert.ToInt32(reader[9]), reader[10].ToString(), reader[11].ToString(), Convert.ToInt32(reader[12]), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong.\n" + ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return toReturn;
        }
        #endregion

        #region Employees
        /// <summary>
        /// Function to add an employee to the database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool CreateEmployee(Employee employee)
        {
            bool succesfulExecution = false;
            int rowsAffected = 0;
            String sql = "INSERT INTO employees VALUES (@id, @active, @firstName, @surName, @username, @picture, @password, @phoneNumber, @address, @city, @postalcode, @emailAddress, @dateOfBirth, @spouseName, @spousePhoneNumber, @bsn, @functions, @preferredShift)";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@id", employee.Id);
            command.Parameters.AddWithValue("@active", employee.Active);
            command.Parameters.AddWithValue("@firstName", employee.FirstName);
            command.Parameters.AddWithValue("@surName", employee.SurName);
            command.Parameters.AddWithValue("@username", employee.UserName);
            command.Parameters.AddWithValue("@picture", "TempPicture"); //TEMP HAS TO CHANGE
            command.Parameters.AddWithValue("@password", SHA512(employee.Password));
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
                conn.Open();
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
                conn.Close();
            }
            return succesfulExecution;
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
            String sql = "UPDATE employees SET active = @active, firstName = @firstName, surName = @surName, username = @username, picture = @picture, phoneNumber = @phoneNumber, address = @address, city = @city, postalcode = @postalcode, emailAddress = @emailAddress, dateOfBirth = @dateOfBirth, spouseName = @spouseName, spousePhoneNumber = @spousePhoneNumber, bsn = @bsn, functions = @function, preferredShift = @preferredShift WHERE id = @id";
            MySqlCommand command = new MySqlCommand(sql, conn);
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
                conn.Open();
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
                conn.Close();
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
            Employee toReturn = null;

            String sql = "SELECT id, active, firstName, surName, username, emailAddress, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhoneNumber, functions, postalcode, city, preferredShift FROM employees WHERE id = @employeeId";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@employeeId", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    toReturn = new Employee(Convert.ToInt32(reader[0]), (bool)reader[1], reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), "", reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), Convert.ToDateTime(reader[8]), Convert.ToInt32(reader[9]), reader[10].ToString(), reader[11].ToString(), Convert.ToInt32(reader[12]), reader[13].ToString(), reader[14].ToString(), reader[15].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return toReturn;
        }

        /// <summary>
        /// Function to get a list of employees from the database on the condition that they are marked as active
        /// </summary>
        /// <returns>A list of Employee objects with all data found about them in the database</returns>
        public List<Employee> GetActiveEmployeesFromDB()
        {
            List<Employee> e = new List<Employee>();
            String sql = "SELECT * FROM employees WHERE active = 1";
            MySqlCommand command = new MySqlCommand(sql, conn);

            try
            {
                conn.Open();
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
                    e.Add(emp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employees.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return e;
        }

        /// <summary>
        /// A function to get a list of employees from the database
        /// </summary>
        /// <returns>A list of Employee objects containing all employees found in the database</returns>
        public List<Employee> GetEmployeesFromDB()
        {
            List<Employee> e = new List<Employee>();
            String sql = "SELECT * FROM employees";
            MySqlCommand command = new MySqlCommand(sql, conn);

            try
            {
                conn.Open();
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
                    e.Add(emp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employees.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return e;
        }
        #endregion

        #region Stock
        /// <summary>
        /// Function to add an item to the database
        /// </summary>
        /// <param name="item"></param>
        public void CreateItem(Item item)
        {
            String sql = "INSERT INTO items VALUES (@id, @name, @brand, @code, @category, @quantity, @price, @active, @description)";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@id", item.Id);
            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@brand", item.Brand);
            command.Parameters.AddWithValue("@code", item.Code);
            command.Parameters.AddWithValue("@category", item.Category);
            command.Parameters.AddWithValue("@quantity", item.Quantity);
            command.Parameters.AddWithValue("@price", item.Price);
            command.Parameters.AddWithValue("@active", item.Active);
            command.Parameters.AddWithValue("@description", item.Description);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Function to update an item with the given id in the database
        /// </summary>
        /// <param name="item"></param>
        public void UpdateItem(Item item)
        {
            String sql = "UPDATE items SET name = @name, brand = @brand, code = @code, category = @category, quantity = @quantity, price = @price, active = @active, description = @description  WHERE id = @id";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@id", item.Id);
            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@brand", item.Brand);
            command.Parameters.AddWithValue("@code", item.Code);
            command.Parameters.AddWithValue("@category", item.Category);
            command.Parameters.AddWithValue("@quantity", item.Quantity);
            command.Parameters.AddWithValue("@price", item.Price);
            command.Parameters.AddWithValue("@active", item.Active);
            command.Parameters.AddWithValue("@description", item.Description);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Function to get an item from the database with a certain id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An Item object with all data belonging to the item with that id, as found in the database</returns>
        public Item GetItem(int id)
        {
            Item item = null;
            String sql = "SELECT id, name, brand, code, category, quantity, price, active, description FROM items WHERE id = @itemId";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@itemId", id);
            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item = new Item(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToInt32(reader[3]), Convert.ToString(reader[4]), Convert.ToInt32(reader[5]), Convert.ToDouble(reader[6]), Convert.ToBoolean(reader[7]), Convert.ToString(reader[8]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return item;
        }

        /// <summary>
        /// A function to get all items from the database
        /// </summary>
        /// <returns>A list of Item objects with all items found in the database</returns>
        public List<Item> GetItemsFromDB()
        {
            List<Item> items = new List<Item>();
            String sql = "SELECT * FROM items";
            MySqlCommand command = new MySqlCommand(sql, conn);

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();

                int id, code, quantity;
                string name, brand, category, description;
                double price;
                bool active;

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"]);
                    code = Convert.ToInt32(reader["code"]);
                    quantity = Convert.ToInt32(reader["quantity"]);
                    name = Convert.ToString(reader["name"]);
                    brand = Convert.ToString(reader["brand"]);
                    category = Convert.ToString(reader["category"]);
                    description = Convert.ToString(reader["description"]);
                    price = Convert.ToDouble(reader["price"]);
                    active = Convert.ToBoolean(reader["active"]);

                    Item i = new Item(id, name, brand, code, category, quantity, price, active, description);
                    items.Add(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving items.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return items;
        }
        #endregion

        #region Scheduling
        /// <summary>
        /// A function to add a shift to the database
        /// </summary>
        /// <param name="shift"></param>
        public void AddShiftToDb(Shift shift)
        {
            int shiftId = 0;
            String sql = ("INSERT INTO shifts VALUES (@id, @date, @shiftType); SELECT LAST_INSERT_ID()");
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@id", shift.Id);
            command.Parameters.AddWithValue("@date", shift.Date);
            command.Parameters.AddWithValue("@shiftType", shift.ShiftTime);

            try
            {
                conn.Open();
                shiftId = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();

                //ClearShift(shiftId);

                foreach (int employeeId in shift.EmployeeIds)
                {
                    AddIdToShift(shiftId, employeeId);
                }
            }
        }

        /// <summary>
        /// A function to clear all information related to a shift with a given id from the database
        /// </summary>
        /// <param name="shiftId"></param>
        public void ClearShift(int shiftId)
        {
            String sql = "DELETE FROM working_employees WHERE shiftId = @shiftId";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@shiftId", shiftId);

            try
            {
                conn.Open();
                int test = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// A function to add an employee id to a certain shift id in the database
        /// </summary>
        /// <param name="shiftId"></param>
        /// <param name="employeeId"></param>
        public void AddIdToShift(int shiftId, int employeeId)
        {
            String sql = "INSERT INTO working_employees (shiftId, employeeId) VALUES ((SELECT id FROM shifts where id = @shiftId), @employeeId)";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@shiftId", shiftId);
            command.Parameters.AddWithValue("@employeeId", employeeId);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// A function to get a list of shifts that are scheduled between two dates
        /// </summary>
        /// <param name="dateMonday"></param>
        /// <param name="dateSunday"></param>
        /// <returns>A list of Shift objects</returns>
        public List<Shift> getWeekData(DateTime dateMonday, DateTime dateSunday)
        {
            List<Shift> weekShifts = new List<Shift>();
            Shift temp;
            List<int> workingEmployeeIds;

            string dateMondaySql = dateMonday.ToString("yyyy-MM-dd");
            string dateSundaySql = dateSunday.ToString("yyyy-MM-dd");

            String sql = "SELECT * FROM shifts WHERE date >= @dateMonday AND date <= @dateSunday";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@dateMonday", dateMondaySql);
            command.Parameters.AddWithValue("@dateSunday", dateSundaySql);

            try
            {
                conn.Open();
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

                    String getEmployeesSql = "SELECT employeeId FROM working_employees WHERE shiftId = @shiftId";
                    MySqlCommand getEmployeesCommand = new MySqlCommand(getEmployeesSql, conn);
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
                MessageBox.Show("Error loading shifts from database.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return weekShifts;
        }

        /// <summary>
        /// A function to get a shift from the database based on the time and date entered
        /// </summary>
        /// <param name="date"></param>
        /// <param name="shiftTime"></param>
        /// <returns>A Shift object that matches the entered date and time</returns>
        public Shift GetShift(DateTime date, ShiftTime shiftTime)
        {
            Shift shift = null;
            string dateSql = date.ToString("yyyy-MM-dd HH:mm:ss");
            String sql = "SELECT count(*) FROM shifts WHERE date = @date AND shiftType = @shiftType";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@date", dateSql);
            command.Parameters.AddWithValue("@shiftType", shiftTime);

            try
            {
                conn.Open();
                int shiftExists = Convert.ToInt32(command.ExecuteScalar());
                if (shiftExists != 0)
                {
                    String sql1 = "SELECT id FROM shifts WHERE date = @date AND shiftType = @shiftType";
                    MySqlCommand command1 = new MySqlCommand(sql1, conn);
                    command1.Parameters.AddWithValue("@date", dateSql);
                    command1.Parameters.AddWithValue("@shiftType", shiftTime);
                    MySqlDataReader reader = command1.ExecuteReader();
                    while (reader.Read())
                    {
                        shift = new Shift(Convert.ToInt32(reader[0]), date, shiftTime);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading shifts from database.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return shift;
        }

        /// <summary>
        /// A function to get a list of employees that work a certain shift
        /// </summary>
        /// <param name="shiftId"></param>
        /// <returns>A list of Employee items that are associated with a certain shift id</returns>
        public List<Employee> GetShiftEmployees(int shiftId)
        {
            List<Employee> shiftEmployees = new List<Employee>();
            List<int> shiftEmployeeIds = new List<int>();
            String sql = "SELECT count(*) FROM working_employees WHERE shiftId = @shiftId";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@shiftId", shiftId);

            try
            {
                conn.Open();
                int shiftHasEmployees = Convert.ToInt32(command.ExecuteScalar());
                if (shiftHasEmployees > 0)
                {
                    String sql2 = "SELECT employeeId FROM working_employees WHERE shiftId = @shiftId";
                    MySqlCommand command2 = new MySqlCommand(sql2, conn);
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
                MessageBox.Show("Error loading shifts from database.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            foreach (int i in shiftEmployeeIds)
            {
                shiftEmployees.Add(GetEmployee(i));
            }

            return shiftEmployees;
        }

        /// <summary>
        /// A function to get the amount of employees that are assigned to a certain shift
        /// </summary>
        /// <param name="shiftId"></param>
        /// <returns>The number of employees scheduled for that shift</returns>
        public int ShiftOccupation(int shiftId)
        {
            int occupation = 0;

            String sql = "SELECT COUNT(shiftId) FROM working_employees WHERE shiftId = @shiftId";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@shiftId", shiftId);

            try
            {
                conn.Open();
                occupation = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return occupation;
        }

        /// <summary>
        /// A function to check if a shift exists on a certain time/date combination
        /// </summary>
        /// <param name="date"></param>
        /// <param name="shiftTime"></param>
        /// <returns>The shift id if a shift exists, otherwise 0</returns>
        public int ShiftExist(DateTime date, ShiftTime shiftTime)
        {
            int shiftId = 0;
            String sql = "SELECT id FROM shifts WHERE date = @date AND shiftType = @shiftType";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@shiftType", shiftTime);

            try
            {
                conn.Open();
                shiftId = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return shiftId;
        }

        public List<int> GetEmployeesPerDepartment(int shiftId, string departmentName)
        {
            List<int> employeeIds = new List<int>();
            String sql = "SELECT employeeId FROM working_employees WHERE departmentId = (SELECT id FROM departments WHERE departmentName = @departmentName) AND shiftId = @shiftId";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@departmentName", departmentName);
            command.Parameters.AddWithValue("@shiftId", shiftId);

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employeeIds.Add(Convert.ToInt32(reader[0]));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee id's from database.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return employeeIds;
        }
        #endregion

        #region Departments
        /// <summary>
        /// A function to add a department to the database
        /// </summary>
        /// <param name="departmentName"></param>
        public void CreateNewDepartment(string departmentName)
        {
            String sql = "INSERT INTO departments (departmentName) VALUES (@departmentName)";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@departmentName", departmentName);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// A function to remove a department from the database
        /// </summary>
        /// <param name="departmentName"></param>
        public void RemoveDepartment(string departmentName)
        {
            String sql = "DELETE FROM departments WHERE departmentName = @departmentName";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@departmentName", departmentName);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// A function to get a list of all departments found in the database
        /// </summary>
        /// <returns>A list of Department objects matching those found in the database</returns>
        public List<string> GetAllDepartments()
        {
            List<string> allDepartments = new List<string>();
            String sql = "SELECT departmentName FROM departments";
            MySqlCommand command = new MySqlCommand(sql, conn);

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allDepartments.Add(reader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return allDepartments;
        }
        #endregion

        #region Statistics
        // To be created
        #endregion

        #region Miscellaneous
        /// <summary>
        /// Function to hash a string with the SHA512 algorithm
        /// </summary>
        /// <param name="input"></param>
        /// <returns>A string hashed with SHA512</returns>
        private string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
        #endregion
    }
}
