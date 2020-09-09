using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JobCard.Models;
using JobCard.Entities;
using System.Net.Mail;

namespace JobCard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JobCardContext _context;
        public HomeController(ILogger<HomeController> logger,
            JobCardContext context)
        {
            _logger = logger;
            _context = context;
        }
        /// <summary>
        /// User job-card form page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var jobCard = new JobCardViewModel();
            return View(jobCard);
        }
        /// <summary>
        /// Job-card Post method
        /// </summary>
        /// <param name="jobCardViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(JobCardViewModel jobCardViewModel)
        {
            try
            {
                Random r = new Random();
                if (ModelState.IsValid)
                {
                    var job = new JobCards
                    {
                        CreatedDate = DateTime.Now,
                        DateOfCompletion = jobCardViewModel.DateOfCompletion,
                        Designation = jobCardViewModel.Designation,
                        Division = jobCardViewModel.Division,
                        Email = jobCardViewModel.Email,
                        Indentor = jobCardViewModel.Indentor,
                        isAccept = false,
                        isReject = false,
                        isComplete = false,
                        //JobId = "JOB" + r.Next(100000, 999999),
                        Name = jobCardViewModel.Name,
                        NatureOfService = jobCardViewModel.NatureOfService,
                        PhoneNumber = jobCardViewModel.PhoneNumber
                    };
                    _context.Add(job);
                    _context.SaveChanges();
                    var temp = job.Id.ToString();
                    var jobId = "JOB" + temp.PadLeft(6, '0');
                    var updateJobId = _context.JobCards.FirstOrDefault(x => x.Id == job.Id);
                    updateJobId.JobId = jobId;
                    _context.SaveChanges();


                    await SendMail(jobCardViewModel);


                    _logger.LogInformation("Add Job Card");
                    jobCardViewModel.Id = job.Id;
                    jobCardViewModel.JobId = job.JobId;
                    jobCardViewModel.CreatedDate = job.CreatedDate;
                }

                return View(jobCardViewModel);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /// <summary>
        /// Send-mail to admin
        /// </summary>
        /// <param name="jobCardViewModel"></param>
        /// <returns></returns>
        private async Task SendMail(JobCardViewModel jobCardViewModel)
        {
            try
            {
                string senderID = "SenderMailId";
                string senderPassword = "password";
                MailMessage mail = new MailMessage();
                mail.To.Add("ReceiverMailId");
                mail.From = new MailAddress(senderID, "JOB-CARD");
                mail.Priority = MailPriority.High;
                mail.Subject = "Job-Card";
                mail.Body = @"<html><head><style>table {font-family: arial, sans-serif;border-collapse: collapse; width: 100%;}
                                th {padding: 10px;font-size: 24px;}td { border: 1px solid #dddddd; text-align: left; padding: 8px;}
                                tr:nth-child(even) { background-color: #dddddd;}</style></head>
                                <body><table><tr><th colspan='3'>Job-Card</th></tr>
                                <tr><td>Name</td><td>" + jobCardViewModel.Name + "</td></tr>"+
                                "<tr><td>Date</td><td>" + jobCardViewModel.CreatedDate.ToShortDateString() + "</td></tr>" + 
                                "<tr><td>Service</td><td>" + jobCardViewModel.NatureOfService + "</td></tr>" + 
                                "<tr><td>Mobile Number</td><td>" + jobCardViewModel.PhoneNumber + "</td></tr></table></body></html>";
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



