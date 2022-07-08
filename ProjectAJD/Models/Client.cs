using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ProjectAJD.Models
{
    public class Client
    {
        [Key]
        public virtual long Id { get; set; }
        [Required(ErrorMessage = "All the fields are required")]
        public virtual string Name { get; set; }
        [Required(ErrorMessage = "All the fields are required")]
        public virtual string Age { get; set; }
        [Required(ErrorMessage = "All the fields are required")]
        public virtual string Gender { get; set; }
    }

    public class EFProjectAJDEntities : DbContext
    {
        public DbSet<Client> clients { get; set; }
    }
}