using System.IO;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public static class ConnectionString
    {
        static string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\connectionstring.cfg";

        /// <summary>
        /// Function to get the connection string from a config file
        /// </summary>
        public static string Read()
        {
            string connectionString = null;
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
                Create();
                MessageBox.Show("No connection file found. Empty file has been created in application root directory.");
            }
            catch (IOException)
            {
                MessageBox.Show(ErrorMessages.readError);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }

            }

            return connectionString;
        }

        /// <summary>
        /// Function to create a new config file with default values 
        /// </summary>
        private static void Create()
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
                MessageBox.Show(ErrorMessages.createError);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
    }
}
