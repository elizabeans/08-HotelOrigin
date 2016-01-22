using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOrigin.Core.Domain
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int NumberOfBeds { get; set; }
        public bool HasTv { get; set; }
        public object Customer { get; set; }
    }
}
