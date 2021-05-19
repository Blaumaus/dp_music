using System;
using BLL.DTO;
using BLL.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Repositories;
using DAL;

namespace BLL.Services
{
    public class RegistrationService : IAccountService
    {
        private readonly PasswordHasher passwordHasher;
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        public RegistrationService(dp_musicContext context, IMapper mapper)
        {
            passwordHasher = new PasswordHasher();
            unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
        }
        public async Task Register(UserRegistrationDto userDto)
        {
            if (!EmailHelper.Validate(userDto.Email))
                throw new FormatException("Email is not valid");

            if (unitOfWork.User.Find(u => u.Email == userDto.Email).Any())
                throw new Exception("User with such Email already exists!");

            if (unitOfWork.User.Find(u => u.Login == userDto.UserName).Any())
                throw new Exception("User with such UserName already exists!");

            string hashedPassword = passwordHasher.HashPassword(userDto.Password);
            userDto.Password = hashedPassword;
            var user = _mapper.Map<User>(userDto);
            user.Id = Guid.NewGuid().ToString();
            user.Role = "User";
            unitOfWork.User.Create(user);
            await unitOfWork.SaveAsync();

        }

    }
}

