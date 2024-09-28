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
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [Remote("IsCategoryExist", "Category", AdditionalFields = "CategoryId,CategoryName", HttpMethod = "POST", ErrorMessage = "Category Already Exist")]
        [StringLength(50)]
        public string CategoryName { get; set; }


        /// <summary>
        /// 1=Yes,  0=No
        /// </summary>
        [Required]
        public int IsActive { get; set; }
    }
}
