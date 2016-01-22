using HotelOrigin.Core.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HotelOrigin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            CustomerRepository.LoadFromDisk();
            RoomRepository.LoadFromDisk();
            ReservationRepository.LoadFromDisk();
        }
    }
}
