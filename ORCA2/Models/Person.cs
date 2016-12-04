using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ORCA2.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }

    public class PersonDBContext : DbContext
    {
        public PersonDBContext()
            : base("DefaultConnection")
        { }
        public DbSet<Person> People { get; set; }
    }
}