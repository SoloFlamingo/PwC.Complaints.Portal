using PwC.Complaints.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwC.Complaints.Portal.Repositories
{
    public interface IComplaintRepository
    {
        Task AddComplaintAsync(string Title, String Message, ComplaintTopic Topic);
        Task<List<Complaint>> GetUserComplaintsAsync(string userId);
        Task<List<Complaint>> GetPendingAdminComplaintsAsync();
        Task UpdateComplaintToResolvedAsync(int ComplaintId);
        Task UpdateComplaintToDismissedAsync(int ComplaintId);
    }
}
