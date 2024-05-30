using Hyra_bil.models;
using Hyra_bil;
using System.Windows;

namespace VehicleApp
{
    public partial class MainWindow : Window
    {
        public VehicleViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new VehicleViewModel();
            DataContext = ViewModel;
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            AddVehicleWindow addVehicleWindow = new AddVehicleWindow();
            if (addVehicleWindow.ShowDialog() == true)
            {
                Vehicle newVehicle = addVehicleWindow.NewVehicle;
                if (newVehicle != null)
                {
                    ViewModel.AddVehicle(newVehicle);
                }
            }
        }
    }
}
