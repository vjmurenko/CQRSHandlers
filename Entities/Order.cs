using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Order : Entity
    {
        [Required]
        public string Email { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}