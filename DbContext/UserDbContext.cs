using Microsoft.EntityFrameworkCore;
using RESTfullAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfullAPI
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public  DbSet<UserModel> users { get; set; }


        protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(! optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server =. ; database= userDB; integrated security=true");
            }
            base.OnConfiguring(optionsBuilder);
        }


    }
}
