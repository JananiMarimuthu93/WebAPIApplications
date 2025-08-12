using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public int DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public virtual  Department? Department { get; set; }
}
