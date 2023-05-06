using System.Collections;
using System.Collections.Generic;

namespace TechnoTest.Models.Identity
{
    public class UserGroup : BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}