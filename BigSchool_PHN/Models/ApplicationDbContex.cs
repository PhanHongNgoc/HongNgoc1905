﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BigSchool_PHN.Models
{
    public class ApplicationDbContex : IdentityDbContext <ApplicationUser>
    {
        public DbSet <Course> Courses { get; set; }
        public DbSet <Category> Categories { get; set; }
        public ApplicationDbContex()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContex Create()
        {
            return new ApplicationDbContex();
        }
    }
}