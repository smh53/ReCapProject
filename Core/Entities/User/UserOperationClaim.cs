using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.User
{
   public class UserOperationClaim
    {
        public int Id { get; set; }

       
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
