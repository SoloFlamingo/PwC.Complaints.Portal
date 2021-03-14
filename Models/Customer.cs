using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwC.Complaints.Portal.Models
{
    public class Customer : ApplicationUser
    {
        public List<Complaint> UserComplaints { get; set; }
    }
}
