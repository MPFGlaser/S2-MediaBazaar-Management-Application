﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaBazaar_ManagementSystem.classes;
using MySql.Data;
using MySql.Data.MySqlClient;


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

        // Creates a new employee entry in the database
        public void CreateEmployee(Employee employee)
        {
            String sql = "INSERT INTO employees VALUES (@id, @active, @firstName, @surName, @username, @password, @phoneNumber, @address, @emailAddress, @dateOfBirth, @spouseName, @spousePhoneNumber, @bsn, @functions)";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@id", 0);
            command.Parameters.AddWithValue("@active", true);
            command.Parameters.AddWithValue("@firstName", employee.FirstName);
            command.Parameters.AddWithValue("@surName", employee.SurName);
            command.Parameters.AddWithValue("@username", employee.UserName);
            command.Parameters.AddWithValue("@password", employee.Password);
            command.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
            command.Parameters.AddWithValue("@address", employee.Address);
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
    }
}
