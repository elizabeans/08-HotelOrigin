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
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        private static bool hasTvChecked = false;

        public AddRoomWindow()
        {
            InitializeComponent();
        }

        private void buttonSaveRoom_Click(object sender, RoutedEventArgs e)
        {
            Guid id = RoomRepository.CreateGuid();
            try
            {
                Room room = new Room
                {
                    RoomId = id,
                    RoomNumber = int.Parse(textBoxRoomNumber.Text),
                    NumberOfBeds = int.Parse(textBoxNumberOfBeds.Text),
                    HasTv = hasTvChecked
                };
                
                RoomRepository.Add(room);
                Close();
            }

            catch (Exception exception)
            {
                MessageBox.Show("Enter a valid number for the Room Number and/or Number of Beds");
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            hasTvChecked = true;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            hasTvChecked = false;
        }
    }
}
