using AutoMapper;
using UserManager.Core.Dtos.Responses;
using UserManager.Core.RepositotyContracts;
using UserManager.Core.ServiceContracts;

namespace UserManager.Core.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<List<UserResponse>> GetAllUsers() =>
        _mapper.Map<List<UserResponse>>(await _usersRepository.FindAllUsers());
}