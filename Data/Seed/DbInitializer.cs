using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using PwC.Complaints.Portal.Data;
using PwC.Complaints.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace PwC.ComplaintsPortal.Data
{
    public class DbInitializer
    {
        private class NormalUserData
        {
            public Customer userInfo;
            public string password;
        }
        private class AdminUserData
        {
            public AdminUser userInfo;
            public string password;
        }

        public static void Initialize(ApplicationDbContext context,
                                        UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();

            var AdminUsers = new AdminUserData[]
            {
               new AdminUserData{
                    userInfo =  new AdminUser{
                        Email="marwanisme98@hotmail.co.uk",
                        UserName="marwanisme98@hotmail.co.uk",
                        PhoneNumber="0797057401"
                    },
                    password = "1234@Marwan"
                },
               new AdminUserData{
                    userInfo =  new AdminUser{
                        Email="faisalalasali98@gmail.com",
                        UserName="faisalalasali98@gmail.com",
                        PhoneNumber="0775466457"
                    },
                    password = "1234@Faisal"
                }
            };

            var NormalUsers = new NormalUserData[]
            {
                new NormalUserData{
                    userInfo =  new Customer{
                        Email="ahmadjaber@gmail.com",
                        UserName="ahmadjaber@gmail.com",
                        PhoneNumber="0772366457"
                    },
                    password = "1234@Jaber"
                },
                   new NormalUserData{
                    userInfo =  new Customer{
                        Email="ramabeyt@gmail.com",
                        UserName="ramabeyt@gmail.com",
                        PhoneNumber="0772366481"
                    },
                    password = "1234@Rama"
                },
            };



            foreach (NormalUserData normalUser in NormalUsers)
            {
                userManager.CreateAsync(normalUser.userInfo, normalUser.password).Wait();
            }
            context.SaveChanges();

            foreach (AdminUserData adminUser in AdminUsers)
            {
                userManager.CreateAsync(adminUser.userInfo, adminUser.password).Wait();
            }
            context.SaveChanges();

            var Complaints = new Complaint[] {
                new Complaint
                {
                    ComplaintTitle = "Test Complaint",
                    ComplaintMessage = "A very long description of test complaint",
                    Topic = ComplaintTopic.LoginIssue,
                    Status = ComplaintStatus.PendingResolution,
                    CustomerId = context.Customers.Where(x=>x.NormalizedEmail=="ahmadjaber@gmail.com".ToUpper()).FirstOrDefault().Id,
                    SubmittedOn = DateTime.Now
                }
            };

            foreach (Complaint complaint in Complaints)
            {
                context.Complaints.Add(complaint);
            }
            context.SaveChanges();

        }
    }
}
