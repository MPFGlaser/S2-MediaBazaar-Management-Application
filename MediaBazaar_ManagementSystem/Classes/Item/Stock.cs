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
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }
        public int ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }
    }
}
