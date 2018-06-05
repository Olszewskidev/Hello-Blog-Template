using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EmailData
    {
        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string SenderName { get; set; }
        [Required]
        [EmailAddress]
        public string SenderMail { get; set; }
        [Required]
        public string SenderText { get; set; }
        [Required]
        public string SenderSubject { get; set; }
    }
}