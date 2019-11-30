using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SF.Domain.Entities;
using SF.Infrastructure;
using SF.Services.Helpers;
using SF.Services.Interfaces;
using SF.Services.Models;
using SF.Services.Models.Bands;

namespace SF.Services
{
    public class BandService : IBandService
    {
        private readonly IMapper _mapper;
        private readonly SFDbContext _DBContext;

        public BandService(IMapper mapper, SFDbContext dbContext)
        {
            _mapper = mapper;
            _DBContext = dbContext;
        }

        public async Task<PagedResultDTO<BandDTO>> GetBandsPageAsync(int page, int pageSize)
        {
            var query = _DBContext.Bands
                .Include(band => band.BandGenres)
                .ThenInclude(bg => bg.Genre);

            var pagedResult = await _DBContext.GetPage<BandEntity, BandDTO>(_mapper, query, page, pageSize);
            return pagedResult;
        }
    }
}
