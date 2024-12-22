﻿using AutoMapper;
using Chat.Shared.DTOs;
using DAL.ChatDBContext;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AcountServices : IAcountServices
    {
        private readonly ChatContext _chatContext;
        private readonly IMapper _mapper;

        public AcountServices(ChatContext chatContext, IMapper mapper)
        {
            _chatContext = chatContext;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(UserDTO dto, CancellationToken cancellationToken)
        {
            var usernameExist = await _chatContext.Users.
                                        AsNoTracking().
                                        AnyAsync(u => u.Username == dto.Username, cancellationToken);

            if(!usernameExist)
            {
                throw new Exception($"{nameof(dto.Username)} alredy exists");
            }

            var user = _mapper.Map<User>(dto);

            await _chatContext.Users.AddAsync(user, cancellationToken);
            await _chatContext.SaveChangesAsync(cancellationToken);

            return user;
        }    

    }
}
