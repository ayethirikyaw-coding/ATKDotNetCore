using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATKDotNetCore.PizzaApi.Models
{
    [Table("Tbl_Pizza")]
    public class PizzaModel
    {
        [Key]
        [Column("PizzaId")]
        public int Id { get; set; }

        [Column("Pizza")]
        public string? Name { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }
    }
}
