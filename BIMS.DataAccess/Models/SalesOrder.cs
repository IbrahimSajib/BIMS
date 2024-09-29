using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.DataAccess.Models
{
    public class SalesOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesOrderId { get; set; }


        [Required]
        [DisplayName("Product")]
        public int ProductId { get; set; }


        [DisplayName("Customer")]
        public int? CustomerId { get; set; }


        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Sale Price")]
        public decimal SalePrice { get; set; }


        [Required]
        public DateTime SaleDate { get; set; } = DateTime.Now.Date;


        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }


        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }


        [NotMapped]
        public IEnumerable<SelectListItem> ProductDDL { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> CustomerDDL { get; set; }
    }
}
