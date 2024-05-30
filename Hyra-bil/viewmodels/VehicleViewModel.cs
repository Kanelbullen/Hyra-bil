using Hyra_bil.models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

public class VehicleViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Vehicle> Vehicles { get; set; } = new ObservableCollection<Vehicle>();
    private ObservableCollection<Vehicle> _filteredVehicles;
    public ObservableCollection<Vehicle> FilteredVehicles
    {
        get => _filteredVehicles;
        set
        {
            _filteredVehicles = value;
            OnPropertyChanged(nameof(FilteredVehicles));
        }
    }

    private Vehicle _selectedVehicle;
    public Vehicle SelectedVehicle
    {
        get => _selectedVehicle;
        set
        {
            _selectedVehicle = value;
            OnPropertyChanged(nameof(SelectedVehicle));
        }
    }

    public VehicleViewModel()
    {
        Vehicles.Add(new Car("ABC123", "Model S", "Tesla", 2020, 15000));
        Vehicles.Add(new Truck("DEF456", "Actros", "Mercedes", 2018, 20000));
        Vehicles.Add(new Motorcycle("GHI789", "Ninja", "Kawasaki", 2021, 500));
        FilteredVehicles = new ObservableCollection<Vehicle>(Vehicles);
    }

    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
        FilterVehicles(FilterText); 
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        Vehicles.Remove(vehicle);
        FilterVehicles(FilterText); 
    }

    private ICommand _removeVehicleCommand;
    public ICommand RemoveVehicleCommand
    {
        get
        {
            if (_removeVehicleCommand == null)
                _removeVehicleCommand = new RelayCommand(param => RemoveVehicle((Vehicle)param), param => param is Vehicle);
            return _removeVehicleCommand;
        }
    }

    private ICommand _rentVehicleCommand;
    public ICommand RentVehicleCommand
    {
        get
        {
            if (_rentVehicleCommand == null)
                _rentVehicleCommand = new RelayCommand(param => RentVehicle((Vehicle)param), param => param is Vehicle && !((Vehicle)param).IsRented);
            return _rentVehicleCommand;
        }
    }

    private ICommand _returnVehicleCommand;
    public ICommand ReturnVehicleCommand
    {
        get
        {
            if (_returnVehicleCommand == null)
                _returnVehicleCommand = new RelayCommand(param => ReturnVehicle((Vehicle)param), param => param is Vehicle && ((Vehicle)param).IsRented);
            return _returnVehicleCommand;
        }
    }

    private string _filterText;
    public string FilterText
    {
        get => _filterText;
        set
        {
            _filterText = value;
            OnPropertyChanged(nameof(FilterText));
            FilterVehicles(_filterText);
        }
    }

    private void FilterVehicles(string filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
        {
            FilteredVehicles = new ObservableCollection<Vehicle>(Vehicles);
        }
        else
        {
            FilteredVehicles = new ObservableCollection<Vehicle>(Vehicles.Where(v =>
                v.Model.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                v.Brand.Contains(filter, StringComparison.OrdinalIgnoreCase)));
        }
    }

    public void RentVehicle(Vehicle vehicle)
    {
        if (vehicle != null)
        {
            vehicle.IsRented = true;
            OnPropertyChanged(nameof(FilteredVehicles));
        }
    }

    public void ReturnVehicle(Vehicle vehicle)
    {
        if (vehicle != null)
        {
            vehicle.IsRented = false;
            OnPropertyChanged(nameof(FilteredVehicles));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
