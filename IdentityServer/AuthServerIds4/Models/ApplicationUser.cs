﻿using Microsoft.AspNetCore.Identity;

namespace AuthServerIds4.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}