using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToDoListClassLibrary.Models
{
    [Table("Shoppinglist")]
    public partial class Shoppinglist
    {
        public Shoppinglist()
        {
            ShoppingListItems = new HashSet<ShoppingListItem>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }

        [InverseProperty(nameof(ShoppingListItem.Shoppinglist))]
        public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}
