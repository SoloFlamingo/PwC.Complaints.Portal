using PwC.Complaints.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwC.Complaints.Portal.Helpers
{
    public static class ComplaintJsonHelper
    {
        public static string ComplaintTopicToString(ComplaintTopic complaintTopic)
        {
            return complaintTopic switch
            {
                ComplaintTopic.FinancialIssue => "Financial Issue",
                ComplaintTopic.LoginIssue => "Login Issue",
                ComplaintTopic.OtherIssue => "Other Issue",
                _ => "Invalid Topic",
            };
        }
        public static string ComplaintStatusToString(ComplaintStatus complaintStatus)
        {
            return complaintStatus switch
            {
                ComplaintStatus.Dismissed => "Dismissed",
                ComplaintStatus.PendingResolution => "Pending Resolution",
                ComplaintStatus.Resolved => "Resolved",
                _ => "Invalid Status",
            };
        }
    }
}
