using System.Collections;
using System.Collections.Generic;

namespace TechnoTest.Models.Identity
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        
        public ICollection<User> Users { get; set; }
    }
}