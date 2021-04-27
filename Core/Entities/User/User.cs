using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.User
{
   public class User : IEntities
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        //public  Customer Customer { get; set; }
        [MaxLength(500)]
        public byte[] PasswordHash { get; set; }
        [MaxLength(500)]
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
    }
}
