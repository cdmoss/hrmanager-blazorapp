using AutoMapper;
using HRManager.Api.Data;
using HRManager.Common;
using HRManager.Common.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Api.Services
{
    public interface IUserService
    {
        List<MemberAdminReadEditDto> GetMembers();
    }
    public class EntityUserService : IUserService
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;

        public EntityUserService(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MemberAdminReadEditDto> GetMembers()
        {
            var members = _context.Members.ToList();
            return _mapper.Map<List<MemberAdminReadEditDto>>(members);
        }
    }
}
