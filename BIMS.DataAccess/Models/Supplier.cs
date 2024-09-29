using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.DataAccess.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }

        [Required]
        [DisplayName("Supplier Name")]
        [StringLength(50)]
        public string SupplierName { get; set; }

        [Required]
        [DisplayName("Supplier Code")]
        [StringLength(10)]
        [Remote("IsSupplierCodeExist", "Supplier", AdditionalFields = "SupplierId,SupplierName", HttpMethod = "POST", ErrorMessage = "Supplier Code Already Exist")]
        public string SupplierCode { get; set; }

        [Required]
        [DisplayName("Contact Info")]
        [StringLength(25)]
        public string ContactInfo { get; set;}

        /// <summary>
        /// 1=Yes,  0=No
        /// </summary>
        [Required]
        public int IsActive { get; set; }


        public virtual List<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
    }
}
