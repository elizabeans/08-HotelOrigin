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
    /// Interaction logic for RoomListWindow.xaml
    /// </summary>
    public partial class RoomListWindow : Window
    {
        private Room currentlySelectedRoom = null;

        public RoomListWindow()
        {
            InitializeComponent();
            dataGridRooms.ItemsSource = RoomRepository.GetAll();
        }

        private void buttonAddRoom_Click(object sender, RoutedEventArgs e)
        {
            AddRoomWindow addRoomWindow = new AddRoomWindow();
            addRoomWindow.ShowDialog();
        }

        private void dataGridRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentlySelectedRoom = (Room)dataGridRooms.SelectedItem;
        }

        private void buttonDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomRepository.Delete(currentlySelectedRoom.RoomId);
        }
    }
}
