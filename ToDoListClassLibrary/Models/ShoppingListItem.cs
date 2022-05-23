using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToDoListClassLibrary.Models
{
    public partial class ShoppingListItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [Column("checked")]
        public bool Checked { get; set; }
        [Column("shoppinglistId")]
        public int ShoppinglistId { get; set; }

        [ForeignKey(nameof(ShoppinglistId))]
        [InverseProperty("ShoppingListItems")]
        public virtual Shoppinglist Shoppinglist { get; set; }
    }
}
