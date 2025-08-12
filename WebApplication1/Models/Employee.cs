using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public int DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    [JsonIgnore]
    public virtual  Department? Department { get; set; }
}
