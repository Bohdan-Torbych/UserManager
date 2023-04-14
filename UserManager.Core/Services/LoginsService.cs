using AutoMapper;
using UserManager.Core.Dtos.Requests;
using UserManager.Core.Dtos.Responses;
using UserManager.Core.Entities;
using UserManager.Core.RepositotyContracts;
using UserManager.Core.ServiceContracts;

namespace UserManager.Core.Services;

public class LoginsService : ILoginsService
{
    private readonly ILoginsRepository _loginsRepository;
    private readonly IMapper _mapper;

    public LoginsService(ILoginsRepository loginsRepository, IMapper mapper)
    {
        _loginsRepository = loginsRepository;
        _mapper = mapper;
    }

    public async Task<LoginResponse> AddNewLogin(LoginAddRequest loginAddRequest) =>
        _mapper.Map<LoginResponse>(await _loginsRepository.SaveLogin(_mapper.Map<Login>(loginAddRequest)));

    public async Task<List<LoginResponse>> GetAllLogins() =>
        _mapper.Map<List<LoginResponse>>(await _loginsRepository.FindAllLogins());
}