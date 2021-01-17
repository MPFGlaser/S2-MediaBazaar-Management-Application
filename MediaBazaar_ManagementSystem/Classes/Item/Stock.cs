using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem.Classes.Item
{
    public class Stock
    {
        private int productId;

        private int quantity;

        public Stock(int givenQuantity, int givenPId)
        {
            Quantity = givenQuantity;
            ProductId = givenPId;
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }
        public int ProductId
        {
            get
            {
                return this.productId;
            }
            set
            {
                this.productId = value;
            }
        }
     }
}
