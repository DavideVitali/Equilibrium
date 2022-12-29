using Equilibrium.Components.OperationResult;
using Equilibrium.Components.SortableTable;
using Equilibrium.Models.Repositories.Entities;
using Equilibrium.Models.Repositories.Stores;
using Microsoft.AspNetCore.Mvc;

namespace Equilibrium.Controllers
{
    public class TableController : Controller
    {
        private readonly IRepository<Employee> employees;

        public TableController(IRepository<Employee> repo)
        {
            employees = repo;
        }
        public IActionResult Index()
        {
            return View(employees.GetAll());
        }

        public IActionResult FilterEmployees(SortableTableFilter filter)
        {
            var x = filter;
            return OperationResult.Success(x);
        }
    }
}
