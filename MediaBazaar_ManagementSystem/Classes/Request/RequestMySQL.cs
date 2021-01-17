using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    class RequestMySQL : IRequestStorage
    {
        MySqlConnection connection;
        string connectionString;
        IEmployeeStorage employeeStorage;

        List<Request> allRequests;

        public RequestMySQL()
        {
            connectionString = ConnectionString.Read();
            connection = new MySqlConnection(connectionString);
            employeeStorage = new EmployeeMySQL();
        }

        public List<Request> GetAll()
        {
            allRequests = new List<Request>();
            String query = "SELECT requests.id, requests.senderId, requests.receiverId, requests.shiftId, requests.status, shifts.date, shifts.shiftType, shifts.id " +
                "FROM requests, shifts " +
                "WHERE requests.shiftId = shifts.id " +
                "AND status = 2 " +
                "ORDER BY shifts.date;";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee sender = employeeStorage.Get(Convert.ToInt32(reader[1]));
                    Employee receiver = employeeStorage.Get(Convert.ToInt32(reader[2]));

                    allRequests.Add(new Request(Convert.ToInt32(reader[0]), sender.FirstName, sender.SurName, receiver.FirstName, receiver.SurName, Convert.ToDateTime(reader[5]), Convert.ToInt32(reader[6]), Convert.ToInt32(reader[7]), Convert.ToInt32(reader[2]), Convert.ToInt32(reader[1])));
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.Generic(ex);
            }
            finally
            {
                connection.Close();
            }
            return allRequests;
        }

        public bool TurnDown (int selectedIndex)
        {
            bool success = false;
            int rowsAffected = 0;

            String query = "UPDATE requests SET status = 1 WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", allRequests[selectedIndex].ID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.Generic(ex);
                success = false;
            }
            finally
            {
                connection.Close();
            }
            return success;
        }

        public bool Permit (int selectedIndex)
        {
            bool success = false;
            int requestRowsAffected = 0;
            int shiftRowsAffected = 0;

            String requestQuery = "UPDATE requests SET status = 3 WHERE id = @id";
            MySqlCommand requestCommand = new MySqlCommand(requestQuery, connection);
            requestCommand.Parameters.AddWithValue("@id", allRequests[selectedIndex].ID);

            String shiftQuery = "UPDATE working_employees SET employeeId = @receiverId WHERE shiftId = @shiftId AND employeeId = @senderId";
            MySqlCommand shiftCommand = new MySqlCommand(shiftQuery, connection);
            shiftCommand.Parameters.AddWithValue("@receiverId", allRequests[selectedIndex].ReceiverID);
            shiftCommand.Parameters.AddWithValue("@shiftId", allRequests[selectedIndex].ShiftID);
            shiftCommand.Parameters.AddWithValue("@senderId", allRequests[selectedIndex].SenderID);

            try
            {
                connection.Open();
                requestRowsAffected = requestCommand.ExecuteNonQuery();
                shiftRowsAffected = shiftCommand.ExecuteNonQuery();
                if (requestRowsAffected > 0 && shiftRowsAffected > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.Generic(ex);
                success = false;
            }
            finally
            {
                connection.Close();
            }
            return success;
        }
    }
}