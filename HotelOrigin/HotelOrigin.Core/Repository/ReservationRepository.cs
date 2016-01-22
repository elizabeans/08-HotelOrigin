using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelOrigin.Core.Domain;
using System.IO;
using Newtonsoft.Json;

namespace HotelOrigin.Core.Repository
{
    public class ReservationRepository
    {
        private static ObservableCollection<Reservation> reservations = new ObservableCollection<Reservation>();

        // Create
        public static Reservation Create()
        {
            Reservation reservation = new Reservation();

            reservations.Add(reservation);

            return reservation;
        }

        public static void Add(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        public static Guid CreateGuid()
        {
            return Guid.NewGuid();
        }

        // Read
        public static Reservation GetByReservationID(Guid id)
        {
            return reservations.FirstOrDefault(c => c.ReservationId == id);
        }

        public static ObservableCollection<Reservation> GetAll()
        {
            return reservations;
        }

        // Update
        
        // Delete
        public static void Delete(Guid id)
        {
            var reservation = GetByReservationID(id);

            reservations.Remove(reservation);
        }

        public static void Delete(Reservation reservation)
        {
            reservations.Remove(reservation);
        }

        // Save/Load to Disk
        public static void SaveToDisk()
        {
            string json = JsonConvert.SerializeObject(reservations);
            File.WriteAllText("reservations.json", json);
        }

        public static void LoadFromDisk()
        {
            if(File.Exists("reservations.json"))
            {
                string json = File.ReadAllText("reservations.json");
                reservations = JsonConvert.DeserializeObject<ObservableCollection<Reservation>>(json);
            }
        }
    }
}
