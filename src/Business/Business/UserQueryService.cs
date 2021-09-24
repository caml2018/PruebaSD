using Business.DTOs;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public interface IUserQueryService
    {
        Task<DataCollection<UserDto>> GetAllAsync(int page, int take, IEnumerable<int> customers = null);
        Task<UserDto> GetAsync(int id);
        public List<UserDto> GetAllUsers();
    }
    public class UserQueryService:IUserQueryService
    {
        private readonly ApplicationDbContext _context;

        public UserQueryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<DataCollection<UserDto>> GetAllAsync(int page, int take, IEnumerable<int> user = null)
        {
            var collection = await _context.user
                .Where(x => user == null || user.Contains(x.usuID))
                .OrderBy(x => x.usuID)
                .GetPagedAsync(page, take); ;

            return collection.MapTo<DataCollection<UserDto>>();// MapTo<DataCollection<UserDto>>();
        }
        public async Task<UserDto> GetAsync(int id)
        {
            return (await _context.user.SingleAsync(x => x.usuID == id)).MapTo<UserDto>();
        }
        public List<UserDto> GetAllUsers()
        {
            var result = _context.user.ToList();
            List<UserDto> collection=new List<UserDto>();
            foreach (var item in result)
            {
                collection.Add(new UserDto
                {
                    usuID = item.usuID,
                    nombre=item.nombre,
                    apellido=item.apellido
                }) ;
            }
            
            return collection ; 
        }
    }
}
