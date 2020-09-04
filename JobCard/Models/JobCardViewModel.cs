﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobCard.Models
{
    public class JobCardViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string JobId { get; set; }
        public string PhoneNumber { get; set; }
        public string Designation { get; set; }
        public string Division { get; set; }
        public int Indentor { get; set; }
        public string NatureOfService { get; set; }
        public DateTime? DateOfCompletion { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isAccept { get; set; }
        public bool isReject { get; set; }
        public bool isComplete { get; set; }
    }
}
