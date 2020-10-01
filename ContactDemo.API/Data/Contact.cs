using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContactDemo.API.Data
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [StringLength(100)]
        [Required]
        public string JobTitle { get; set; }

        [StringLength(100)]
        [Required]
        public string Company { get; set; }

        [Phone]
        [StringLength(50)]
        public string PhoneNo { get; set; }

        [EmailAddress]
        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [StringLength(500)]
        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime LastDateConnected { get; set; }
    }
}
