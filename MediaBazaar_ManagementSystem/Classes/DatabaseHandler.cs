using MediaBazaar_ManagementSystem.classes;
using MediaBazaar_ManagementSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace MediaBazaar_ManagementSystem.Classes
{
    public class DatabaseHandler
    {
        MySqlConnection conn;
        string connectionString;
        string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\connectionstring.cfg";

        public DatabaseHandler()
        {
            GetConnectionString();
            conn = new MySqlConnection(connectionString);
        }

        public Employee LoginUser(string username, string password)
        {
            Employee toReturn = null;

            String sql = "SELECT count(*) FROM employees WHERE username = @username AND password = @password";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", SHA512(password));

            try
            {
                conn.Open();
                int correctLogin = Convert.ToInt32(command.ExecuteScalar());
                if(correctLogin > 0)
                {
                    String sql2 = "SELECT id, active, firstName, surName, username, emailAddress, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhoneNumber, functions, postalcode, city FROM employees WHERE username = @username AND password = @password";
                    MySqlCommand command2 = new MySqlCommand(sql2, conn);
                    command2.Parameters.AddWithValue("@username", username);
                    command2.Parameters.AddWithValue("@password", SHA512(password));

                    try
                    {
                        MySqlDataReader reader = command2.ExecuteReader();
                        while (reader.Read())
                        {
                            toReturn = new Employee(Convert.ToInt32(reader[0]), (bool)reader[1], reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), "", reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), Convert.ToDateTime(reader[8]), Convert.ToInt32(reader[9]), reader[10].ToString(), reader[11].ToString(), Convert.ToInt32(reader[12]), reader[13].ToString(), reader[14].ToString());
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

        // Creates a new employee entry in the database
        public void CreateEmployee(Employee employee)
        {
            String sql = "INSERT INTO employees VALUES (@id, @active, @firstName, @surName, @username, @picture, @password, @phoneNumber, @address, @city, @postalcode, @emailAddress, @dateOfBirth, @spouseName, @spousePhoneNumber, @bsn, @functions)";
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

        public void UpdateEmployee(Employee employee)
        {
            String sql = "UPDATE employees SET active = @active, firstName = @firstName, surName = @surName, username = @username, picture = @picture, phoneNumber = @phoneNumber, address = @address, city = @city, postalcode = @postalcode, emailAddress = @emailAddress, dateOfBirth = @dateOfBirth, spouseName = @spouseName, spousePhoneNumber = @spousePhoneNumber, bsn = @bsn, functions = @function WHERE id = @id";
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

        public Employee GetEmployee(int id)
        {
            Employee toReturn = null;

            String sql = "SELECT id, active, firstName, surName, username, emailAddress, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhoneNumber, functions, postalcode, city FROM employees WHERE id = @employeeId";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@employeeId", id);

            try
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    toReturn = new Employee(Convert.ToInt32(reader[0]), (bool)reader[1], reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), "", reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), Convert.ToDateTime(reader[8]), Convert.ToInt32(reader[9]), reader[10].ToString(), reader[11].ToString(), Convert.ToInt32(reader[12]), reader[13].ToString(), reader[14].ToString());
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
                string firstName, surName, userName, password, email, phoneNumber, address, spouseName, spousePhone, postalCode, city;
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

                    Employee emp = new Employee(id, active, firstName, surName, userName, password, email, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhone, function, postalCode, city);
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
                string firstName, surName, userName, password, email, phoneNumber, address, spouseName, spousePhone, postalCode, city;
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

                    Employee emp = new Employee(id, active, firstName, surName, userName, password, email, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhone, function, postalCode, city);
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

        public void AddIdToShift(int shiftId, int employeeId)
        {
            String sql = "INSERT INTO working_employees VALUES ((SELECT id FROM shifts where id = @shiftId), @employeeId)";
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

                foreach(Shift s in weekShifts)
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
                if(shiftHasEmployees > 0)
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

            foreach(int i in shiftEmployeeIds)
            {
                shiftEmployees.Add(GetEmployee(i));
            }

            return shiftEmployees;
        }

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

        public List<Item> GetItemsFromDB()
        {
            List<Item> items = new List<Item>();
            String sql = "SELECT * FROM items";
            MySqlCommand command = new MySqlCommand(sql, conn);

            try
            {
                conn.Open();
                MySqlDataReader reader =  command.ExecuteReader();

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

        // Gets the connection string from a config file
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
                if(sr != null)
                {
                    sr.Close();
                }
            }
        }

        // Creates a new config file with default values 
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
                if(sw != null)
                {
                    sw.Close();
                }
            }
        }

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
    }
}
