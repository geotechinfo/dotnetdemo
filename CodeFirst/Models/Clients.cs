using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Clients
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is Required.")]
        [Range(1,100)]
        public int Age { get; set; }
        [Required(ErrorMessage = "Gender is Required.")]
        public string Gender { get; set; }
    }

    public class CodeFirstEntities : DbContext
    {
        public DbSet<Clients> clients { get; set; }

    }
}
public enum GenderOptions
{
    Male = 0,
    Female = 1,
    Others = 2
}