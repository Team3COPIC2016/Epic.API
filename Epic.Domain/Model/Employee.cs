using System;
using System.Collections.Generic;

namespace Epic.Domain.Model
{
    public class Employee : IAuditable
    {
        public string Id { get; set; }
        public string ParentId { get; set; }

        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }

        //Audit
        public string CreatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
