using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
