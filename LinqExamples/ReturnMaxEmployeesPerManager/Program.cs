using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturnMaxEmployeesPerManager
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Employee e = new Employee();
			e.EmployeeId = 101;
			e.FirstName = "Tom";
			e.LastName = "Jones";
			e.HireDate = DateTime.Now.Subtract(TimeSpan.FromDays(40));

			Employee e2 = new Employee();
			e2.EmployeeId = 102;

			Employee e3 = new Employee();
			e3.EmployeeId = 103;
			
			Manager m = new Manager();
			m.EmployeeId = 201;
			m.EmployeesManaged.Add(e);
			m.EmployeesManaged.Add(e2);
			
			Manager m2 = new Manager();
			m2.EmployeesManaged.Add(e3);

			List<Manager> mList = new List<Manager>();
			mList.Add(m);
			mList.Add(m2);

			var bestMgr = mList
							.OrderByDescending(mgr => mgr.EmployeesManaged.Count)
							.FirstOrDefault();

			Console.WriteLine("best manager: " + bestMgr.EmployeeId);
			Console.ReadKey();
		}
	}

	public class Employee 
	{
		public int EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime HireDate { get; set; }

		public Employee()
		{
		}
	}

	public class Manager : Employee
	{
		private List<Employee> _employeesManaged = new List<Employee>();
		public List<Employee> EmployeesManaged
		{
			get { return _employeesManaged; }
			set { _employeesManaged = value; }
		}
	}
}
