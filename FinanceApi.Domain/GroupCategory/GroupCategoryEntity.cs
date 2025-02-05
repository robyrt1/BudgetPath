    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace FinanceApi.Domain.GroupCategory
    {
        public class GroupCategoryEntity
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid Id { get; set; }

            [Required]
            [StringLength(255)]
            public string Descript { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        }
    }
