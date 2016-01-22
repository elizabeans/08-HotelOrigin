using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HotelOrigin.Core;
using HotelOrigin.Core.Domain;
using HotelOrigin.Core.Repository;

namespace HotelOrigin
{
    /// <summary>
    /// Interaction logic for AddReservation.xaml
    /// </summary>
    public partial class AddReservation : Window
    {
        private Customer customerSelected = null;
        private Room roomSelected = null;
        private DateTime checkInDate;
        private DateTime checkOutDate;

        public AddReservation()
        {
            InitializeComponent();
        }

        private void buttonSaveReservation_Click(object sender, RoutedEventArgs e)
        {
            Guid id = ReservationRepository.CreateGuid();

           
            Reservation reservation = new Reservation()
            {
                ReservationId = id,
                Customer = customerSelected,
                Room = roomSelected,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate
            };

            ReservationRepository.Add(reservation);
        }

        private void comboBoxCustomer_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxCustomer.ItemsSource = CustomerRepository.GetAll();
        }

        private void comboxBoxRoom_Loaded(object sender, RoutedEventArgs e)
        {
            comboxBoxRoom.ItemsSource = RoomRepository.GetAll();
        }

        private void comboBoxCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customerSelected = (Customer)comboBoxCustomer.SelectedItem;
        }

        private void comboxBoxRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            roomSelected = (Room)comboxBoxRoom.SelectedItem;
        }

        private void datePickerCheckInDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            checkInDate = (DateTime)picker.SelectedDate;
        }

        private void datePickerCheckOutDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            checkOutDate = (DateTime)picker.SelectedDate;
        }
    }
}
