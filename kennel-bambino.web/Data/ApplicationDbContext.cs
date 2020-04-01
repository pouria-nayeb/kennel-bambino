using System;
using System.Collections.Generic;
using System.Text;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace kennel_bambino.web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region Pets

        public DbSet<Group> Groups { get; set; }

        public DbSet<EyeColor> EyeColors { get; set; }

        public DbSet<Pattern> Patterns { get; set; }

        public DbSet<BodyType> BodyTypes { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Photo> Photos { get; set; }

        #endregion

        #region Carousel

        public DbSet<Carousel> Carousels { get; set; }

        #endregion

        #region Contact

        public DbSet<Contact> Contacts { get; set; }

        #endregion

    }
}
