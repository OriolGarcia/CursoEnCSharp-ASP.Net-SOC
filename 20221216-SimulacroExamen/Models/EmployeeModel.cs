using _20221216_SimulacroExamen.Dal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _20221216_SimulacroExamen.Models
{
    public class EmployeeModel
    {
        public List<EmployeeSlim> GetEmployes()
        {

            var dbContext = new cifo_OGSContext();
            var employees = dbContext.Employees.Where(e=> e.Country=="USA")
                .OrderBy(e => e.FirstName).Select(e => new EmployeeSlim
                {
                    EmployeeId = e.EmployeeId,
                    Employee = e.FirstName,
                    Title = e.Title,
                    TitleOfCourtesy=e.TitleOfCourtesy,
                    Country=e.Country,
                    HireDate=e.HireDate,
                    Salary=e.Salary
                }).ToList();
            return employees;
        }
    }
    public class EmployeeSlim
    {
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public string Country { get; set; }
        public DateTime? HireDate { get; set; }
        public float? Salary { get; set; }



    }
}

