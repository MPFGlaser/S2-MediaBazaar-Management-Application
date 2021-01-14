namespace MediaBazaar_ManagementSystem.Classes.Item
{
    public class Request
    {
        private int id;
        private int productId;
        private int quantity;
        private string status;
        private int requestedBy;
        private string Date;

        public Request(int givenId, int givenPId, int givenquantity, string givenStatus, int givenRBy, string givenDate)
        {
            Id = givenId;
            ProductId = givenPId;
            Quantity = givenquantity;
            Status = givenStatus;
            RequestedBy = givenRBy;
            DatE = givenDate;
        }

        public int Id
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
            }
        }
        public int ProductId
        {
            get
            {
                return productId;
            }
            private set
            {
                productId = value;
            }
        }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            private set
            {
                quantity = value;
            }
        }
        public int RequestedBy
        {
            get
            {
                return requestedBy;
            }
            private set
            {
                requestedBy = value;
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
            private set
            {
                status = value;
            }
        }
        public string DatE
        {
            get
            {
                return Date;
            }
            private set
            {
                Date = value;
            }
        }
    }
}
