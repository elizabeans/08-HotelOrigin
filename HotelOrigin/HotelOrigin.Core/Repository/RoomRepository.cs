using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelOrigin.Core;
using HotelOrigin.Core.Domain;
using Newtonsoft.Json;
using System.IO;

namespace HotelOrigin.Core.Repository
{
    public class RoomRepository
    {
        private static ObservableCollection<Room> rooms = new ObservableCollection<Room>();

        // Create
        public static Room Create()
        {
            Room room = new Room();

            rooms.Add(room);

            return room;
        }

        public static void Add(Room room)
        {
            rooms.Add(room);
        }

        public static Guid CreateGuid()
        {
            return Guid.NewGuid();
        }

        // Read
        public static Room GetByRoomId(Guid id)
        {
            return rooms.FirstOrDefault(c => c.RoomId == id);
        }

        public static ObservableCollection<Room> GetAll()
        {
            return rooms; 
        }

        // Update

        // Delete
        public static void Delete(Guid id)
        {
            var room = GetByRoomId(id);

            rooms.Remove(room);
        }

        public static void Delete(Room room)
        {
            rooms.Remove(room);
        }
        // Save/Load to Disk
        public static void SaveToDisk()
        {
            string json = JsonConvert.SerializeObject(rooms);
            File.WriteAllText("rooms.json", json);
        }

        public static void LoadFromDisk()
        {
            if (File.Exists("rooms.json"))
            {
                string json = File.ReadAllText("rooms.json");
                rooms = JsonConvert.DeserializeObject<ObservableCollection<Room>>(json);
            }
        }
    }
}
