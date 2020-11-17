using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    class ItemMySQL : IItemStorage
    {
        MySqlConnection connection;
        string connectionString;

        public ItemMySQL()
        {
            connectionString = ConnectionString.Read();
            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Adds the specified item to the database.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Whether the query was successful.</returns>
        public bool Create(Item item)
        {
            bool success = false;
            int rowsAffected = 0;

            String query = "INSERT INTO items VALUES (@id, @name, @brand, @code, @category, @quantity, @price, @active, @description)";
            MySqlCommand command = new MySqlCommand(query, connection);
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
                connection.Open();
                command.ExecuteNonQuery();
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
                MessageBox.Show(ErrorMessages.fileNotFound + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return success;
        }

        /// <summary>
        /// Gets the item with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The item found with the specified id.</returns>
        public Item Get(int id)
        {
            Item output = null;
            String query = "SELECT id, name, brand, code, category, quantity, price, active, description FROM items WHERE id = @itemId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@itemId", id);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    output = new Item(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToInt32(reader[3]), Convert.ToString(reader[4]), Convert.ToInt32(reader[5]), Convert.ToDouble(reader[6]), Convert.ToBoolean(reader[7]), Convert.ToString(reader[8]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMessages.fileNotFound + ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return output;
        }

        /// <summary>
        /// Gets all items.
        /// <para>Has the option to only return active items</para>
        /// </summary>
        /// <param name="activeOnly">if set to <c>true</c> [active only].</param>
        /// <returns>A list of Items.</returns>
        public List<Item> GetAll(bool activeOnly)
        {
            List<Item> output = new List<Item>();
            String query = "SELECT * FROM items";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
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
                    output.Add(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving items.\n" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return output;
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Whether the update was successful.</returns>
        public bool Update(Item item)
        {
            bool success = false;
            int rowsAffected = 0;

            String query = "UPDATE items SET name = @name, brand = @brand, code = @code, category = @category, quantity = @quantity, price = @price, active = @active, description = @description  WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
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
                connection.Open();
                command.ExecuteNonQuery();
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
                MessageBox.Show(ErrorMessages.fileNotFound + ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return success;
        }
    }
}
