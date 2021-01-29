using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AS_Identity
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Wanted to implement this; but couldn't get Password Hash to work


            ApplicationUser volunteer = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "volunteer@mail.nl",
            };

            ApplicationUser customer = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
