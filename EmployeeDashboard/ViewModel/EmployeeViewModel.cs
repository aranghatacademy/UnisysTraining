namespace EmployeeDashboard;
using System.ComponentModel;
using System.Windows.Input;

public class EmployeeViewModel : INotifyPropertyChanged
{
	//Model
	private readonly Employee employee;

	public EmployeeViewModel()
	{
		employee = new Employee();
	}

	public string Name
	{
		get => employee.Name;
		set
		{
			if (employee.Name != value)
			{
				employee.Name = value;
				OnPropertyChanged(nameof(Name));
			}
		}
	}

	public string Email
	{
		get => employee.Email;
		set
		{
			if (employee.Email != value)
			{
				employee.Email = value;
				OnPropertyChanged(nameof(Email));
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

	public void Save()
	{
        employee.Save();
    }

	public ICommand SaveCommand => new RelayCommand(Save);
}

public class RelayCommand : ICommand
{
    private readonly Action execute;
    private readonly Func<bool> canExecute;
    public RelayCommand(Action execute, Func<bool> canExecute = null)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }
    public event EventHandler CanExecuteChanged;
    public bool CanExecute(object parameter)
    {
        return canExecute == null || canExecute();
    }

    public void Execute(object parameter)
    {
        execute();
    }
}