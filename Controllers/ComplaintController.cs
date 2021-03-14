using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PwC.Complaints.Portal.Models;
using PwC.Complaints.Portal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PwC.Complaints.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintRepository ComplaintRepository;
        private readonly ILogger<ComplaintController> Logger;
        private readonly UserManager<ApplicationUser> UserManager;

        public ComplaintController(IComplaintRepository ComplaintRepository, ILogger<ComplaintController> logger ,UserManager<ApplicationUser> UserManager
            )
        {
            this.ComplaintRepository = ComplaintRepository;
            Logger = logger;
            this.UserManager = UserManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserComplaints()
        {

            
            ApplicationUser user = await UserManager.FindByNameAsync(ClaimTypes.NameIdentifier);
            if (user as Customer is not null)
            {
                try
                {
                    List<Complaint> Complaints = await ComplaintRepository.GetUserComplaintsAsync(
                        User.FindFirstValue(ClaimTypes.NameIdentifier)
                        );
                    return Ok(Complaints);
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                try
                {
                    List<Complaint> Complaints = await ComplaintRepository.GetPendingAdminComplaintsAsync();
                    Logger.LogInformation(Complaints.ToString());
                    return Ok(Complaints);
                }
                catch
                {
                    return BadRequest();
                }
            }
            
        }


        [Route("declined/{id}")]
        [HttpPatch]
        public async Task<IActionResult> SetComplaintStatusToDeclined(int id)
        {
            try
            {
                await ComplaintRepository.UpdateComplaintToDismissedAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("resolved/{id}")]
        [HttpPatch]
        public async Task<IActionResult> SetComplaintStatusToResolved(int id)
        {
            try
            {
                await ComplaintRepository.UpdateComplaintToResolvedAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("new")]
        [HttpPut]
        public async Task<IActionResult> NewComplaint(string Title, String Message, ComplaintTopic Topic)
        {

            try
            {
                await ComplaintRepository.AddComplaintAsync(Title, Message, Topic);
                //Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))

                Logger.LogInformation("HELLO");
                return Ok("HELLO");
            }
            catch(Exception e)
            {
                Logger.LogInformation("Title: " + Title);
                Logger.LogInformation("Message: " + Message);
                Logger.LogInformation("Topic: " + Topic.ToString());
                Logger.LogInformation(e.StackTrace);
                return BadRequest();
            }
        }

    }
}
