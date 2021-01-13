using System;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public static class ErrorMessages
    {
        private static string fileNotFound = Properties.Resources.fileNotFound;
        private static string readError = Properties.Resources.readError;
        private static string createError = Properties.Resources.createError;
        private static string genericError = Properties.Resources.genericError;
        private static string retrieveEmployeeError = Properties.Resources.retrieveEmployeeError;
        private static string retrieveItemError = Properties.Resources.retrieveItemError;
        private static string loadShiftError = Properties.Resources.loadShiftError;
        private static string informationInvalidError = Properties.Resources.informationInvalidError;
        private static string databaseSaveError = Properties.Resources.databaseSaveError;

        private static void Show(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }

        private static void Show(string errorMessage, Exception e)
        {
            MessageBox.Show(errorMessage + System.Environment.NewLine + e.ToString());
        }

        public static void FNF()
        {
            Show(fileNotFound);
        }

        public static void Read()
        {
            Show(readError);
        }

        public static void Create()
        {
            Show(createError);
        }

        public static void Generic(Exception e)
        {
            Show(genericError, e);
        }

        public static void RetrieveEmployee(Exception e)
        {
            Show(retrieveEmployeeError, e);
        }

        public static void RetrieveItem(Exception e)
        {
            Show(retrieveItemError, e);
        }

        public static void Shift(Exception e)
        {
            Show(loadShiftError, e);
        }

        public static void InformationInvalid()
        {
            Show(informationInvalidError);
        }

        public static void DatabaseSave()
        {
            Show(databaseSaveError);
        }

        public static void DatabaseSave(Exception e)
        {
            Show(databaseSaveError, e);
        }
    }
}