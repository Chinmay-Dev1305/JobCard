using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobCard.Models
{
    public class JobCardViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        public string JobId { get; set; }
        [Required(ErrorMessage = "Mobile Number is Required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Designation is Required")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Division is Required")]
        public string Division { get; set; }
        [Required]
        public int Indentor { get; set; }
        [Required(ErrorMessage = "Nature Of Service is Required")]
        public string NatureOfService { get; set; }
         [Required(ErrorMessage = "Date Of Completion is Required")]
        public DateTime? DateOfCompletion { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isAccept { get; set; }
        public bool isReject { get; set; }
        public bool isComplete { get; set; }
    }
}
