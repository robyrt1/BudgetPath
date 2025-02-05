using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Categories.Queries.Responses
{
    public class GetCategoriesResponse
    {
        public string Category { get; set; }
        public Guid GroupId { get; set; }
        public string DescriptGroup { get; set; }
        public List<SubCategoryResponse> SubCategories { get; set; } = new();
    }

    public class SubCategoryResponse
    {
        public string SubCategory { get; set; }
        public Guid GroupId { get; set; }
        public string DescriptGroup { get; set; }
    }
}
