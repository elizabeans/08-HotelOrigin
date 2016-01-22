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
using System.Windows.Shapes;

namespace HotelOrigin
{
    /// <summary>
    /// Interaction logic for ReservationListWindow.xaml
    /// </summary>
    public partial class ReservationListWindow : Window
    {
        private Reservation currentSelectedReservation = null;

        public ReservationListWindow()
        {
            InitializeComponent();
            dataGridReservations.ItemsSource = ReservationRepository.GetAll();
        }

        private void buttonAddReservation_Click(object sender, RoutedEventArgs e)
        {
            AddReservation addReservation = new AddReservation();
            addReservation.ShowDialog();
        }

        private void buttonDeleteReservation_Click(object sender, RoutedEventArgs e)
        {
            ReservationRepository.Delete(currentSelectedReservation.ReservationId);
        }

        private void dataGridReservations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentSelectedReservation = (Reservation)dataGridReservations.SelectedItem;
        }
    }
}
