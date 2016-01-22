using HotelOrigin.Core;
using HotelOrigin.Core.Domain;
using HotelOrigin.Core.Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelOrigin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonCustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            CustomerListWindow listWindow = new CustomerListWindow();
            listWindow.ShowDialog(); //difference between show and showdialog -- show allows you to make as many windows as you want whereas showdialog just opens it once
        }

        private void buttonRoomManagement_Click(object sender, RoutedEventArgs e)
        {
            RoomListWindow roomListWindow = new RoomListWindow();
            roomListWindow.ShowDialog();
        }

        private void buttonReservationManagement_Click(object sender, RoutedEventArgs e)
        {
            ReservationListWindow reservationWindow = new ReservationListWindow();
            reservationWindow.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CustomerRepository.SaveToDisk();
            RoomRepository.SaveToDisk();
            ReservationRepository.SaveToDisk();
        }

    }
}
