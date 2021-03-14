using Microsoft.EntityFrameworkCore;
using PwC.Complaints.Portal.Data;
using PwC.Complaints.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwC.Complaints.Portal.Repositories
{
    public class ComplaintRepository : IComplaintRepository
    {
        private readonly ApplicationDbContext context;

        public ComplaintRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddComplaintAsync(string Title, String Message, ComplaintTopic Topic)
        {
            await context.Complaints.AddAsync(new Complaint { ComplaintMessage = Message, ComplaintTitle = Title, Topic = ComplaintTopic.FinancialIssue, SubmittedOn = DateTime.Now, Status = ComplaintStatus.PendingResolution, CustomerId = Guid.NewGuid().ToString() });
            context.SaveChanges();
        }

        public async Task<List<Complaint>> GetPendingAdminComplaintsAsync()
        {
            return await context.Complaints.Where(c => c.Status == ComplaintStatus.PendingResolution || c.Status == ComplaintStatus.PendingResolution).ToListAsync();
        }

        public async Task<List<Complaint>> GetUserComplaintsAsync(string userId)
        {
            return await context.Complaints.Where(c => c.CustomerId == userId).ToListAsync();
        }

        public async Task UpdateComplaintToDismissedAsync(int ComplaintId)
        {
            context.Complaints.Where(c => c.ComplaintId == ComplaintId).FirstOrDefault().Status = ComplaintStatus.Dismissed;
            await context.SaveChangesAsync();
        }

        public async Task UpdateComplaintToResolvedAsync(int ComplaintId)
        {
            context.Complaints.Where(c => c.ComplaintId == ComplaintId).FirstOrDefault().Status = ComplaintStatus.Resolved;
            await context.SaveChangesAsync();
        }
    }
}
