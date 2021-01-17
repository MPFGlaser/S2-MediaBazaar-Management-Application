using System;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public static class ErrorMessages
    {
        private static readonly string fileNotFound = Properties.Resources.fileNotFound;
        private static readonly string readError = Properties.Resources.readError;
        private static readonly string createError = Properties.Resources.createError;
        private static readonly string genericError = Properties.Resources.genericError;
        private static readonly string retrieveEmployeeError = Properties.Resources.retrieveEmployeeError;
        private static readonly string retrieveItemError = Properties.Resources.retrieveItemError;
        private static readonly string loadShiftError = Properties.Resources.loadShiftError;
        private static readonly string informationInvalidError = Properties.Resources.informationInvalidError;
        private static readonly string databaseSaveError = Properties.Resources.databaseSaveError;


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