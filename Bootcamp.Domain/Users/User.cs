using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Domain.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int Password { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
