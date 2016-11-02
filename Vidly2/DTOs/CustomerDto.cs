using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly2.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public byte MembershipTypeId { get; set; }
        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}