using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem.Classes.Item
{
    public class Stock
    {
        //private int id;
        private int productId;

        private int quantity;

        public Stock(/*int givenId,*/ int givenQuantity, int givenPId)
        {
            //id = givenId;
            Quantity = givenQuantity;
            ProductId = givenPId;
        }

        /*public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }*/



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
