using PwC.Complaints.Portal.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwC.Complaints.Portal.Models
{
    public class Complaint
    {

        public int ComplaintId { get; set; }
        public String ComplaintTitle { get; set; }
        public String ComplaintMessage { get; set; }
        public DateTime SubmittedOn { get; set; }
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
        public ComplaintStatus Status { get; set; }

        public string StatusString => ComplaintJsonHelper.ComplaintStatusToString(Status);
        public ComplaintTopic Topic { get; set; }

        public string TopicString => ComplaintJsonHelper.ComplaintTopicToString(Topic);

        public Boolean IsCritical { get; set; }

        public string IsCriticalString => IsCritical ? "Yes" : "No";

    }
}
