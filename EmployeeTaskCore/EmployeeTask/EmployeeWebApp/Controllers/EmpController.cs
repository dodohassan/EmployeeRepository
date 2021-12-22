using Employee.Services.EmpDataService.Employee;
using Employee.ViewModels.EMPS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApp.Controllers
{
	public class EmpController : Controller
	{
		private readonly IEmployeeServices _employeeService;
		public EmpController(IEmployeeServices employeeService)
		{
			_employeeService = employeeService;

		}
		// GET: EmpController
		public ActionResult Index()
		{
			var employees = _employeeService.GetAll();
			return View(employees.Data);
		}

		public IActionResult Details(int? employeeId)
		{
			if (employeeId == null)
			{
				return NotFound();
			}
			var employee = _employeeService.GetById(employeeId.Value);
			if (employee.Data == null)
			{
				return NotFound();
			}
			return View(employee.Data);
		}


		// GET: Employees/Delete/1
		public IActionResult Delete(long? employeeId)
		{
			if (employeeId == null)
			{
				return NotFound();
			}
			var employee = _employeeService.GetById(employeeId.Value);

			return View(employee.Data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(long ID)
		{
			_employeeService.Delete(ID);

			return RedirectToAction(nameof(Index));
		}
		public IActionResult AddOrEdit(int? employeeId)
		{
			ViewBag.PageName = employeeId == null ? "Create Employee" : "Edit Employee";
			ViewBag.IsEdit = employeeId == null ? false : true;
			if (employeeId == null)
			{
				return View();
			}
			else
			{
				var employee = _employeeService.GetById(employeeId.Value);

				if (employee.Data == null)
				{
					return NotFound();
				}
				return View(employee.Data);
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddOrEdit(int employeeId, [Bind("ID,FirstName,LastName,Address,PhoneNumber,Email")] EmployeeVM employeeData)
		{

			if (ModelState.IsValid)
			{
				try
				{
					_employeeService.SaveEmp(employeeData);

				}
				catch (DbUpdateConcurrencyException)
				{
					throw;
				}
				return RedirectToAction(nameof(Index));
			}
			return View(employeeData);
		}
	}
}
