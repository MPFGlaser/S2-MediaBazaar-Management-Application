using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public static class ErrorMessages
    {
        private static string fileNotFound = MediaBazaar_ManagementSystem.Properties.Resources.fileNotFound;
        private static string readError = MediaBazaar_ManagementSystem.Properties.Resources.readError;
        private static string createError = MediaBazaar_ManagementSystem.Properties.Resources.createError;
        private static string genericError = MediaBazaar_ManagementSystem.Properties.Resources.genericError;
        private static string retrieveEmployeeError = MediaBazaar_ManagementSystem.Properties.Resources.retrieveEmployeeError;
        private static string retrieveItemError = MediaBazaar_ManagementSystem.Properties.Resources.retrieveItemError;
        private static string loadShiftError = MediaBazaar_ManagementSystem.Properties.Resources.loadShiftError;

        public static void FNF()
        {
            MessageBox.Show(fileNotFound);
        }

        public static void Read()
        {
            MessageBox.Show(readError);
        }

        public static void Create()
        {
            MessageBox.Show(createError);
        }

        public static void Generic(Exception e)
        {
            MessageBox.Show(genericError + e.ToString());
        }

        public static void RetrieveEmployee(Exception e)
        {
            MessageBox.Show(retrieveEmployeeError + e.ToString());
        }

        public static void RetrieveItem(Exception e)
        {
            MessageBox.Show(retrieveItemError + e.ToString());
        }
        
        public static void Shift(Exception e)
        {
            MessageBox.Show(loadShiftError + e.ToString());
        }
    }
}