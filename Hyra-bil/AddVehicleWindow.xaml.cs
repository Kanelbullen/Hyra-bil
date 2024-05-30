using Hyra_bil.models;
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

namespace Hyra_bil
{
    public partial class AddVehicleWindow : Window
    {
        public Vehicle NewVehicle { get; private set; }

        public AddVehicleWindow()
        {
            InitializeComponent();
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            string type = ((ComboBoxItem)TypeComboBox.SelectedItem)?.Content.ToString();
            string brand = BrandTextBox.Text;
            string model = ModelTextBox.Text;
            if (!int.TryParse(YearTextBox.Text, out int year))
            {
                MessageBox.Show("Invalid year format. Please enter a valid year.");
                return;
            }
            string registrationNumber = RegistrationNumberTextBox.Text;
            string additionalInfo = AdditionalInfoTextBox.Text;

            try
            {
                switch (type)
                {
                    case "Car":
                        if (!int.TryParse(additionalInfo, out int mileage))
                        {
                            MessageBox.Show("Invalid mileage format. Please enter a valid mileage.");
                            return;
                        }
                        NewVehicle = new Car(registrationNumber, model, brand, year, mileage);
                        break;
                    case "Truck":
                        if (!int.TryParse(additionalInfo, out int loadCapacity))
                        {
                            MessageBox.Show("Invalid load capacity format. Please enter a valid load capacity.");
                            return;
                        }
                        NewVehicle = new Truck(registrationNumber, model, brand, year, loadCapacity);
                        break;
                    case "Motorcycle":
                        if (!int.TryParse(additionalInfo, out int engineDisplacement))
                        {
                            MessageBox.Show("Invalid engine displacement format. Please enter a valid engine displacement.");
                            return;
                        }
                        NewVehicle = new Motorcycle(registrationNumber, model, brand, year, engineDisplacement);
                        break;
                    default:
                        MessageBox.Show("Please select a valid vehicle type.");
                        return;
                }
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding vehicle: {ex.Message}");
            }
        }
    }
}
