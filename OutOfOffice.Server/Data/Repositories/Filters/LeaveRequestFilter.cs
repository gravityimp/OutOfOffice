﻿using OutOfOffice.Server.Models.Enums;

namespace OutOfOffice.Server.Data.Repositories.Filters
{
    public class LeaveRequestFilter
    {
        public int? Id { get; set; }
        public List<LeaveStatus> Statuses { get; set; } = [];
        public List<LeaveReason> LeaveReasons { get; set; } = [];
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }

    }
}
