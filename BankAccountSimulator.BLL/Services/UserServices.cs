using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BankAccountSimulator.BLL.DTO;
using BankAccountSimulator.BLL.Interfaces;
using BankAccountSimulator.DAL.Entities;
using BankAccountSimulator.DAL.Interfaces;

namespace BankAccountSimulator.BLL.Services;

public class UserServices : IUserService
{
    private IUnitOfWork _unitOfWork { get; set; }
    private readonly IMapper _mapper;
    private readonly string _pepper;
    private readonly int _iteration = 3;
    
    public UserServices(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _pepper = Environment.GetEnvironmentVariable("PasswordHashPepper_DefaultPepper");
    } 
    
    
    public async Task<UserDTO> ValidateAsync(UserDTO userDto)
    {
        IEnumerable<User> user = await _unitOfWork.Users.FindAsync(u => u.Username == userDto.Username);
        var gotUser = user.FirstOrDefault();
        if (user == null)
        {
            throw new ValidationException(("THe current user does not found"));
        }

        var passwordHash = PasswordHasher.ComputeHash(userDto.Password, gotUser.PasswordHash, _pepper, _iteration);
        if (gotUser.PasswordHash != passwordHash)
            throw new ValidationException("Username or password did not match.");
        
        var u = _mapper.Map<User, UserDTO>(gotUser);
        return u;
    }

    public async Task<UserDTO> RegisterAsync(UserDTO userDto)
    {
        var initUser = new User(userDto.Username)
        {
            PasswordSalt = PasswordHasher.GenerateSalt()
        };
        initUser.PasswordHash =
            PasswordHasher.ComputeHash(userDto.Password, initUser.PasswordSalt, _pepper, _iteration);
        await _unitOfWork.Users.CreateAsync(initUser);
        
        return _mapper.Map<User,UserDTO>(initUser);
    }
    
    
    public async Task<UserDTO> GetAsync(int id)
    {
        var user = await  _unitOfWork.Users.GetAsync(id);
        if (user == null)
            throw new ValidationException("The current user doesnt exist!");
        return _mapper.Map<User, UserDTO>(user);
    }
    
    public async Task<IEnumerable<UserDTO>> GetUsersAsync()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return _mapper.Map<IEnumerable<User>, List<UserDTO>>(users);
    }

    public async IAsyncEnumerable<UserDTO> GetUsersByPageAsync(int page, int pageSize)
    {
        var users = _unitOfWork.Users.GetUsersByPageAsync(page, pageSize);
        await foreach (var u in users)
        { 
            var usersDto = _mapper.Map<User, UserDTO>(u);
            yield return usersDto;
        }
    }

    public async Task<int> GetTotalUsersCountAsync()
    {
        return await _unitOfWork.Users.GetTotalUsersCountAsync();
    }

    public async Task AddMoneyAsync(int id, decimal money)
    {
        await _unitOfWork.AccountRepository.AddMoneyAsync(id, money);
    }

    public async Task WithdrawMoneyAsync(int id, decimal money)
    {
        await _unitOfWork.AccountRepository.WithdrawMoneyAsync(id, money);
    }

    public void Dispose()
    {
      _unitOfWork.Dispose();
    }
}
