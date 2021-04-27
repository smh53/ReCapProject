using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.User
{
  public  class OperationClaim : IEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
