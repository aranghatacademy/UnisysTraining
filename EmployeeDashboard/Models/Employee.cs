using System.IO;

namespace EmployeeDashboard;

//1. Model
public class Employee
{
	public string Name { get; set; }

	public string Email { get; set; }

	public void Save()
	{
		File.AppendAllText("employee.txt", $"{Name},{Email}");
	}
}
