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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void buttonSaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            Guid id = CustomerRepository.CreateGuid();

            if (textBoxFirstName.Text != "" && textBoxLastName.Text != "" && textBoxEmailAddress.Text != "" && textBoxTelephoneNumber.Text != "")
            {
                Customer customer = new Customer
                {
                    FirstName = textBoxFirstName.Text,
                    LastName = textBoxLastName.Text,
                    EmailAddress = textBoxEmailAddress.Text,
                    TelephoneNumber = textBoxTelephoneNumber.Text,
                    Id = id
                };

                CustomerRepository.Add(customer);
                Close();
            }
            else
            {
                MessageBox.Show("Please fill in all the fields.");
            }
        }
    }
}
