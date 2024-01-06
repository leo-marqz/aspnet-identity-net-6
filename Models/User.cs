
using System;
using Microsoft.AspNetCore.Identity;

namespace ASPNetIdentity.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string UrlWebSite { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Status { get; set; } = true;
    }
}