using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Categories.Commands.Requests
{
    public class CreateCategoryRequest
    {
        [Required]
        [StringLength(255)]
        public string Descript { get; set; }

        [Required]
        public Guid GroupId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Guid? ParentId { get; set; }
    }
}
