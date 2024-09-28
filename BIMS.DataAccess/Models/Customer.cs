using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace BIMS.DataAccess.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [DisplayName("Customer Name")]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [DisplayName("Customer Code")]
        [StringLength(10)]
        [Remote("IsCustomerCodeExist", "Customer", AdditionalFields = "CustomerId,CustomerName", HttpMethod = "POST", ErrorMessage = "Customer Code Already Exist")]
        public string CustomerCode { get; set; }

        [Required]
        [DisplayName("Contact Info")]
        [StringLength(25)]
        public string ContactInfo { get; set; }

        /// <summary>
        /// 1=Yes,  0=No
        /// </summary>
        [Required]
        public int IsActive { get; set; }
    }
}
