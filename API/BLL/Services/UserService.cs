using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        readonly UnitOfWork unitOfWork;
        public UserService(dp_musicContext context, IMapper mapper)
        {
            unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
        }

        public UserDTO GetCurrentUser(string id)
        {
            var db_user = unitOfWork.User.Get(id);
            var mapped_user = _mapper.Map<UserDTO>(db_user);
            return mapped_user;
        }
    }
}
