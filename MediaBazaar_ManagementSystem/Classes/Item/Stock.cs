namespace MediaBazaar_ManagementSystem.Classes.Item
{
    public class Stock
    {
        private int productId, quantity;

        public Stock(int givenQuantity, int givenPId)
        {
            Quantity = givenQuantity;
            ProductId = givenPId;
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
    }
}
