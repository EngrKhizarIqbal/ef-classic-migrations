using System.Collections.Generic;

namespace Entities
{
    public class WebUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
