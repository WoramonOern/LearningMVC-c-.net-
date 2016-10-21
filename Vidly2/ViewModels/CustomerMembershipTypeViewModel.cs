using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class CustomerMembershipTypeViewModel
    {
        public Customer customers { get; set; }
        public MembershipType membershiptypes { get; set; }
    }
}