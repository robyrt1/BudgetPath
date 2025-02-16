using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FinanceApi.Domain.GroupCategory;

namespace FinanceApi.Domain.Categories
{
    public class CategoryEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Descript { get; set; }

        [Required]
        public Guid GroupId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? ParentId { get; set; }

        [ForeignKey("GroupId")]
        public GroupCategoryEntity Group {  get; set; }

        [ForeignKey("ParentId")]
        public IEnumerable<CategoryEntity> SubCategories { get; set; }
    }
}
