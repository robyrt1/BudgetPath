    using FinanceApi.Domain.Categories.Port;
    using FinanceApi.Domain.Categories.Queries.Responses;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace FinanceApi.Infra.Data.Repositories.Categories
    {
        public class CategoriesQueriesRespositoryImp : ICategoriesQueriesRespositoryBase
        {
            private readonly AppDbContext _context;

            public CategoriesQueriesRespositoryImp(AppDbContext context)
            {
                _context = context;
            }

            public async  Task<IEnumerable<GetCategoriesResponse>> GetCategories()
            {
                var categories = await _context.Categories
                    .Where(c => c.ParentId == null)
                    .Include(c => c.Group)
                    .Include(c => c.SubCategories)
                        .ThenInclude(sc => sc.Group)
                    .Select(c => new GetCategoriesResponse
                    {
                        Id = c.Id,
                        UserId = c.UserId,
                        Category = c.Descript,
                        GroupId = c.GroupId,
                        DescriptGroup = c.Group.Descript,
                        SubCategories = c.SubCategories
                            .Select(sub => new SubCategoryResponse
                            {
                                SubCategory = sub.Descript,
                                GroupId = sub.GroupId,
                                DescriptGroup = sub.Group.Descript
                            }).ToList()
                    })
                    .ToListAsync();

                return categories;
            }

        public async Task<IEnumerable<GetCategoriesResponse>> GetCategoriesByUser(Guid UserId)
        {
            var categories = await _context.Categories
                .Where(c => c.ParentId == null && (c.UserId == UserId || c.UserId == null))
                .Include(c => c.Group)
                .Include(c => c.SubCategories)
                    .ThenInclude(sc => sc.Group)
                .Select(c => new GetCategoriesResponse
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    Category = c.Descript,
                    GroupId = c.GroupId,
                    DescriptGroup = c.Group.Descript,
                    SubCategories = c.SubCategories
                        .Select(sub => new SubCategoryResponse
                        {
                            SubCategory = sub.Descript,
                            GroupId = sub.GroupId,
                            DescriptGroup = sub.Group.Descript
                        }).ToList()
                })
                .ToListAsync();

            return categories;
        }
    }
    }
