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

        public DatabaseHandler()
        {
            GetConnectionString();
        }

        public void GetConnectionString()
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream("/connectionstring.cfg", FileMode.Open, FileAccess.Read);
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

        private void CreateConnectionStringFile()
        {
            FileStream fs;
            StreamWriter sw;

            try
            {
                fs = new FileStream("/connectionstring.cfg", FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);

                sw.Write("server=localhost;database=pcs3;uid=root;password=secret");
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
