﻿using System;
using System.Collections.Generic;
using System.Text;
using chattinApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace chattinApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    

       public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Message>()
                   .HasOne<AppUser>(a => a.Sender)
                   .WithMany(d => d.Messages)
                   .HasForeignKey(d => d.UserID);
        }
    }
}
