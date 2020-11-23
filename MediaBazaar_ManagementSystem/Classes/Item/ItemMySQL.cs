﻿using MediaBazaar_ManagementSystem.Classes.Item;
using MediaBazaar_ManagementSystem.Controls;
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
        List<Stock> stocks = new List<Stock>();
        List<Request> requests = new List<Request>();

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
                ErrorMessages.Generic(ex);
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
                ErrorMessages.Generic(ex);
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
                ErrorMessages.RetrieveItem(ex);
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
                ErrorMessages.Generic(ex);
            }
            finally
            {
                connection.Close();
            }

            return success;
        }
        /// <summary>
        /// Read the requests
        /// </summary>
        public int ReadRequest(int id)
        {
            int pid = id;
            int quantity = 0;
            this.requests = new List<Request>();
            try
            {
                string sql = "SELECT `quantity` FROM `stock_request` WHERE id = @pId AND status = 'Pending';";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@pId", pid);
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    quantity += Convert.ToInt32(dr[0]);
                }
            }
            finally
            {
                connection.Close();
            }
            return quantity;
        }
        /// <summary>
        /// Read the stock
        /// </summary>
        public List<Stock> ReadStock()
        {
            this.stocks = new List<Stock>();
            try
            {
                string sql = "SELECT `id`, `quantity` FROM `items` ORDER BY `quantity`";
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Stock stock = new Stock(/*Convert.ToInt32(dr[0]),*/ Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]));
                    stocks.Add(stock);
                }
            }
            finally
            {
                connection.Close();
            }
            return stocks;
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="userid">The users id.</param>
        /// <returns>To know who sent the request</returns>
        /// /// <param name="productId">The products id.</param>
        /// <returns>To nkow for which product the request is sent</returns>
        /// /// /// <param name="quantity">The products quantity restock.</param>
        /// <returns>To know how much to restock</returns>
        public void SendStockRequest(int userid, int productId, int quantity)
        {
            try
            {
                string sql = "INSERT INTO stock_request(productid, quantity, status, userid, date) VALUES(@pId, @quantity, @status, @rBy, @rDate)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                string status = "Pending";
                ReadStock();
                cmd.Parameters.AddWithValue("@pId", productId);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@rBy", userid);
                cmd.Parameters.AddWithValue("@rDate", DateTime.Now.Date);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Request has been sent!");
            }
            finally
            {
                connection.Close();
            }
        }

        public void AddToStock(int productId, int quantity, int userid)
        {
            try
            {
                decimal x = 0;
                ReadStock();
                foreach (Stock s in stocks)
                {
                    if (s.ProductId == productId)
                    {
                        x = s.Quantity + quantity;
                    }
                }
                string sql = "UPDATE stock SET quantity = @Quantity WHERE id = @Id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Quantity", x);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Stock is updated!");

                string sql2 = "INSERT INTO stock_request(productId, quantity, status, requestedBy, requestDate) VALUES(@pId, @quantity, @status, @rBy, @rDate)";
                MySqlCommand cmd2 = new MySqlCommand(sql2, connection);
                string status = "Approved";
                cmd2.Parameters.AddWithValue("@pId", productId);
                cmd2.Parameters.AddWithValue("@quantity", quantity);
                cmd2.Parameters.AddWithValue("@status", status);
                cmd2.Parameters.AddWithValue("@rBy", userid);
                cmd2.Parameters.AddWithValue("@rDate", DateTime.Now.Date);
                cmd2.ExecuteNonQuery();

            }
            finally
            {
                connection.Close();
            }
        }
    }
}
