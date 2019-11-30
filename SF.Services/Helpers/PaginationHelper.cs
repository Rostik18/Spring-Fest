using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SF.Infrastructure;
using SF.Services.Interfaces.CustomExceptions;
using SF.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SF.Services.Helpers
{
    public static class PaginationHelper
    {
        public static async Task<PagedResultDTO<TDTO>> GetPage<TEntity, TDTO>(this SFDbContext dbContext, IMapper mapper, 
                             IQueryable<TEntity> query, int page, int pageSize) where TEntity : class where TDTO : class
        {
            if (page < 1)
            {
                throw new BadArgumentException("Page cannot be less than 1.");
            }

            if (pageSize < 1 || pageSize > 50)
            {
                throw new BadArgumentException("Page can contain from 1 to 50 objects.");
            }

            var countOfSkips = (page - 1) * pageSize;

            var entities = await query
                .AsNoTracking()
                .Skip(countOfSkips)
                .Take(pageSize)
                .ToListAsync();

            var DTOs = mapper.Map<List<TDTO>>(entities);

            var pagedResultDTO = new PagedResultDTO<TDTO>
            {
                Data = DTOs,
                Page = page,
                PageSize = pageSize,
                TotalCount = query.Count()
            };

            return pagedResultDTO;
        }
    }
}
