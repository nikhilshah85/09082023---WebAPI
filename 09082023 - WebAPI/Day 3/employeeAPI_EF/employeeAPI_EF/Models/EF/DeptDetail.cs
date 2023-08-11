using System;
using System.Collections.Generic;

namespace employeeAPI_EF.Models.EF;

public partial class DeptDetail
{
    public int DeptNo { get; set; }

    public string? DeptName { get; set; }

    public string? DeptHead { get; set; }
}
