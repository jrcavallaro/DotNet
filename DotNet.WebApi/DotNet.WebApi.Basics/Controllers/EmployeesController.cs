using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Http;

namespace DotNet.WebApi.Basics.Controllers
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Department { get; set; }
	}

	public class EmployeesController : ApiController
	{
		private List<Employee> _employees;

		public EmployeesController()
		{
			_employees = new List<Employee>
								{
									new Employee { Id = 1, Name = "Mary Ann", Department = "Enforcement"},
									new Employee { Id = 2, Name = "Jonah Happy", Department = "Legal"},
									new Employee { Id = 3, Name = "Roberto Feliz", Department = "Accounting"},
									new Employee { Id = 4, Name = "Mary Kay", Department = "Finance"}
								};
		}

		public HttpResponseMessage Get(int id)
		{
			if (id > 9999)
			{
				throw new HttpResponseException(
						new HttpResponseMessage()
							{
								Content = new StringContent("Invalid employee id " + id),
								StatusCode = HttpStatusCode.BadRequest
							}
					);
			}

			var result = GetAllEmployees().FirstOrDefault(e => e.Id.Equals(id));

			return result == null 
						? Request.CreateResponse(HttpStatusCode.NotFound, new StringContent("Employee " + id + " not found"))
						: Request.CreateResponse(HttpStatusCode.OK, result);
		}

		[Queryable]
		public IEnumerable<Employee> GetAllEmployees()
		{
			return _employees;
		}

		//[AcceptVerbs("PUT", "POST")]
		public HttpResponseMessage Employee(Employee employee)
		{
			employee.Id = _employees.Count;

			_employees.Add(employee);

			return Request.CreateResponse(HttpStatusCode.Created, employee);
		}
	}
}
