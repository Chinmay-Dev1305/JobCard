using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using JobCard.Entities;
using JobCard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobCard.Controllers
{
    public class AdminController : Controller
    {
        private readonly JobCardContext _context;

        public AdminController(JobCardContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Admin Login Page
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Admin-Login-Post-Method
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Admin.FirstOrDefault(x => x.UserId == loginViewModel.UserId && x.Password == loginViewModel.Password);
                if (user == null)
                {
                    return View("Login");
                }
                HttpContext.Session.SetString("userId", user.UserId);
            }
            else
            {
                return View("Login");
            }
            return RedirectToAction(nameof(Jobs));
        }

        /// <summary>
        /// Job-List-Page
        /// </summary>
        /// <returns></returns>
        public IActionResult Jobs()
        {
            try
            {
                var jobCards = _context.JobCards.ToList();
                var jobList = jobCards.Select(x => new JobCardViewModel
                {
                    CreatedDate = x.CreatedDate,
                    DateOfCompletion = x.DateOfCompletion,
                    Designation = x.Designation,
                    Division = x.Division,
                    Email = x.Email,
                    Id = x.Id,
                    Indentor = x.Indentor,
                    isAccept = x.isAccept,
                    isReject = x.isReject,
                    Name = x.Name,
                    isComplete = x.isComplete,
                    JobId = x.JobId,
                    NatureOfService = x.NatureOfService,
                    PhoneNumber = x.PhoneNumber
                }).ToList();
                return View(jobList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Logout-Method
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        /// <summary>
        /// Accept-Job by admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Accept(int id)
        {
            try
            {
                var job = _context.JobCards.FirstOrDefault(x => x.Id == id);
                job.isAccept = true;
                _context.SaveChanges();
                await SendMail(job.Email, "Accepted, Job-Id : " + job.JobId);
                return RedirectToAction("Jobs");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Reject-Job by admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Reject(int id)
        {
            try
            {
                var job = _context.JobCards.FirstOrDefault(x => x.Id == id);
                job.isReject = true;
                _context.SaveChanges();
                await SendMail(job.Email, "Rejected, Job-Id : " + job.JobId);
                return RedirectToAction("Jobs");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Complete job by admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Complete(int id)
        {
            try
            {
                var job = _context.JobCards.FirstOrDefault(x => x.Id == id);
                job.isComplete = true;
                _context.SaveChanges();
                return RedirectToAction("Jobs");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Export job-list into Excel-sheet file
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public FileResult Export()
        {
            DataTable dt = new DataTable("JobsList");
            dt.Columns.AddRange(new DataColumn[11] { new DataColumn("Ticket Number"),
                                            new DataColumn("Date"),
                                            new DataColumn("Name"),
                                            new DataColumn("Designation"),
             new DataColumn("Dept/Division"),
             new DataColumn("Intercom/Mobile"),
             new DataColumn("Phone Number"),
             new DataColumn("NatureOfService"),
             new DataColumn("Date Of Completion"),
             new DataColumn("Action"),
             new DataColumn("Status")});

            var jobList = _context.JobCards.ToList();

            foreach (var job in jobList)
            {
                var status = string.Empty;
                if (job.isAccept)
                {
                    status = "Accepted";
                }
                else if (job.isReject)
                {
                    status = "Rejected";
                }
                else
                {
                    status = "Pending";
                }

                dt.Rows.Add(job.JobId, job.CreatedDate.ToShortDateString(), job.Name, job.Designation
                    , job.Division, job.Indentor, job.PhoneNumber, job.NatureOfService, job.DateOfCompletion?.ToShortDateString(), status, job.isComplete ? "Complete" : "Incomplete");
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ComputerCenter-JobCard2020.xlsx");
                }
            }
        }
        /// <summary>
        /// Send mail to user
        /// </summary>
        /// <param name="userMail"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private async Task SendMail(string userMail, string body)
        {
            try
            {
                string senderID = "sendermail";
                string senderPassword = "password";
                MailMessage mail = new MailMessage();
                mail.To.Add(userMail);
                mail.From = new MailAddress(senderID, "JOB-CARD");
                mail.Priority = MailPriority.High;
                mail.Subject = "Job-Card";
                mail.Body = "Your job-card has been " + body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                     (senderID, senderPassword); // ***use valid credentials***
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}