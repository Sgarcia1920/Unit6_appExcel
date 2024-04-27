
using Unit6_appExcel;
using System.IO;
using OfficeOpenXml;
public class Program
{
	
	static void Main(string[] args)
	{
		int employeeCount = 0;
		int option;
		Employee_data[] employees = new Employee_data[20];
		
		
		do
		{
			Console.WriteLine("HUMAN RESOURCES");
			Console.WriteLine("Choose an option \n1)enter information\n2)save file\n3)exitS");
			option = int.Parse(Console.ReadLine());
			switch (option)
			{
				case 1:

					while (true)
					{
						if (employeeCount >= employees.Length)
						{
							Console.WriteLine("Ya has ingresado información para todos los empleados.");
							break;
						}

						Console.WriteLine("Enter the name for employee");
						string name = Console.ReadLine();
						Console.WriteLine("Enter the paternal surname for employee");
						string paternalSurname = Console.ReadLine();
						Console.WriteLine("Enter the mother surname for employee");
						string motherSurname = Console.ReadLine();
						Console.WriteLine("Enter the age for employee");
						int age = int.Parse(Console.ReadLine());
						Console.WriteLine("Enter the number of children for employee");
						int numberOfChildren = int.Parse(Console.ReadLine());

						employees[employeeCount] = new Employee_data
						{
							Name = name,
							Paternal_surname = paternalSurname,
							Mother_surname = motherSurname,
							Age = age,
							Number_of_children = numberOfChildren
						};
						employeeCount++;

						Console.WriteLine("Do you wish to enter information for another employee? (y/n)");
						string response = Console.ReadLine().ToLower();
						if (response != "y")
						{
							break; 
						}
					}
					break;

				case 2:
					string path = @"C:\Users\Ani uwu\Desktop\SEMESTRE 2 POO\Unit 6\excel\Employee.xlsx"; 

					using (var package = new ExcelPackage(new FileInfo(path))) 
					{
						var worksheet = package.Workbook.Worksheets.Add("Employee");
						worksheet.Cells[1, 1].Value = "Name";
						worksheet.Cells[1, 2].Value = "Paternal Surname";
						worksheet.Cells[1, 3].Value = "Mother Surname";
						worksheet.Cells[1, 4].Value = "Age";
						worksheet.Cells[1, 5].Value = "Number of children";

						int row = 2;
						foreach (Employee_data emp in employees)
						{
							if (emp != null) 
							{
								worksheet.Cells[row, 1].Value = emp.Name;
								worksheet.Cells[row, 2].Value = emp.Paternal_surname;
								worksheet.Cells[row, 3].Value = emp.Mother_surname;
								worksheet.Cells[row, 4].Value = emp.Age;
								worksheet.Cells[row, 5].Value = emp.Number_of_children;
								row++;
							}
						}
						package.Save(); 
					}
					break;
					default:
					Console.WriteLine("Nothing");
					break;
			}

		} while (option != 3);

	}
}

