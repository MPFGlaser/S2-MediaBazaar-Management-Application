using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem
{
    public class Request
    {
        private int id, shiftId, senderId, receiverId;
        private string senderFirstName, senderSurName, receiverFirstName, receiverSurName, shiftType;
        private DateTime shiftDate;

        public Request(int id, string senderFirstName, string senderSurName, string receiverFirstName, string receiverSurName, DateTime shiftDate, int shiftType, int shiftId, int receiverId, int senderId)
        {
            this.id = id;
            this.senderFirstName = senderFirstName;
            this.senderSurName = senderSurName;
            this.receiverFirstName = receiverFirstName;
            this.receiverSurName = receiverSurName;
            this.shiftDate = shiftDate;

            if (shiftType == 0)
            {
                this.shiftType = "morning";
            }
            else if (shiftType == 1)
            {
                this.shiftType = "afternoon";
            }
            else if (shiftType == 2)
            {
                this.shiftType = "evening";
            }

            this.shiftId = shiftId;
            this.receiverId = receiverId;
            this.senderId = senderId;
        }

        public int ID { get { return this.id; } }
        public string SenderFirstName { get { return this.senderFirstName; } set { this.senderFirstName = value; } }
        public string ReceiverFirstName { get { return this.receiverFirstName; } set { this.receiverFirstName = value; } }
        public string SenderSurName { get { return this.senderSurName; } set { this.senderSurName = value; } }
        public string ReceiverSurName { get { return this.receiverSurName; } set { this.receiverSurName = value; } }
        public DateTime ShiftDate { get { return this.shiftDate; } set { this.shiftDate = value; } }
        public string ShiftType { get { return this.shiftType; } set { this.shiftType = value; } }
        public int ShiftID { get { return this.shiftId; } set { this.shiftId = value; } }
        public int ReceiverID { get { return this.receiverId; } set { this.receiverId = value; } }
        public int SenderID { get { return this.senderId; } set { this.senderId = value; } }
    }
}
