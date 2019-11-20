using System.Collections.Generic;

namespace Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<WebUser> WebUsers { get; set; }
    }
}
