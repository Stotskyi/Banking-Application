using AutoMapper;
using BankAccountSimulator.BLL.DTO;
using BankAccountSimulator.BLL.Interfaces;
using BankAccountSimulator.PL.Models;
using BankAccountSimulator.PL.UI;
using BankAccountSimulator.PL.UserInputHandlers;

namespace BankAccountSimulator.PL;

public class UserController : IUserController
{
    private IUserService _userService { get; set; }
    private IMapper _mapper { get; set; }
    
    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<UserView> ValidateAsync(UserView user)
    {
        var userDto = _mapper.Map<UserView, UserDTO>(user);
        
        var validatedUser = await _userService.ValidateAsync(userDto);
        
        var validatedUserView = _mapper.Map<UserDTO,UserView>(validatedUser);
        return validatedUserView;
    }

    public async Task<UserView> RegisterAsync(UserView user)
    {
        var userDto = _mapper.Map<UserView, UserDTO>(user);
        var a = await  _userService.RegisterAsync(userDto);
        return  await GetAsync(a.Id);
    }

    
    
    public async Task<UserView> GetAsync(int id)
    {
        var user = await _userService.GetAsync(id);
        return _mapper.Map<UserDTO, UserView>(user);
    }

    public async Task AddMoneyAsync(int id, decimal money)
    {
        await _userService.AddMoneyAsync(id, money);
    }

    public async Task WithdrawMoneyAsync(int id, decimal money)
    {
        await _userService.WithdrawMoneyAsync(id,money);
    }
    
    public async Task FindUserAsync()
    {
        string username = UsernameReader.ReadUsername();
        var foundedUserDTO =  await _userService.GetUsersAsync();
        
        var userView = _mapper.Map<UserDTO, UserView>(foundedUserDTO.FirstOrDefault()!);
        FindUserView.DisplaySearchUser(userView);
        
    }

    public void UpdateUserAsync()
    {
        throw new NotImplementedException();
    }

    public void DeleteUserAsync()
    {
        throw new NotImplementedException();
    }

    public async Task ViewUsersAsync()
    {
        int pageSize = 5;
        int currentPage = 1;
        while(true)
        {
            
            var users = _userService.GetUsersByPageAsync(currentPage, pageSize);
            int totalUsers = await _userService.GetTotalUsersCountAsync();
            List<UserView> userViews = new();
            await foreach (var userDTO in users)
            {
                var uView = _mapper.Map<UserDTO, UserView>(userDTO);
                userViews.Add(uView);
            }
            
            FindUserView.DisplayUserTable(userViews);
            
            
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.LeftArrow && (currentPage - 1) * pageSize < totalUsers)
            {
                currentPage++;
            }
            else if (key.Key == ConsoleKey.RightArrow && currentPage > 1)
            {
                currentPage--;
            }
            else if (key.KeyChar == 'q' || key.KeyChar == 'Q')
            {
                break;
            }
            Console.Clear();
        } 
        Console.Clear();
        
    }
}