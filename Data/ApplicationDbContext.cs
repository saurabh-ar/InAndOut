﻿using InAndOut.Models;
using Microsoft.EntityFrameworkCore;

namespace InAndOut
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Expense> Expenses { get; set; }   
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }   


    }
}
