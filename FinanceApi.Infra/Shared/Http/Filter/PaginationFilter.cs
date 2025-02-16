using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Shared.Http.Filter
{
    public class PaginationFilter
    {
        public int Skip { get; set; }
        public int Top { get; set; }

        public PaginationFilter()
        {
            this.Skip = 0;
            this.Top = 10;
        }

        public PaginationFilter(int skip, int top)
        {
            this.Skip = skip < 0 ? 0 : skip;
            this.Top = top > 100 ? 100 : (top <= 0 ? 10 : top);
        }
    }
}
