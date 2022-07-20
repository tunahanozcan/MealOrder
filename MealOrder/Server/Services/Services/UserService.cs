using AutoMapper;
using AutoMapper.QueryableExtensions;
using MealOrder.Server.Data.Models;
using MealOrder.Server.Services.Infrastruce;
using MealOrder.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrder.Server.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly MealOrderContext context;

        public UserService(IMapper Mapper,MealOrderContext Context)
        {
            mapper = Mapper;
            context = Context;
        }

        public async Task<UserDTO> CreateUser(UserDTO user)
        {
            var dbUser = await context.Users.Where(u => u.Id == user.Id).FirstOrDefaultAsync();
            if (dbUser != null)
                throw new Exception("İlgili kayıt zaten mevcut");


            dbUser = mapper.Map<Users>(user);

            await context.Users.AddAsync(dbUser);
            int result = await context.SaveChangesAsync();

            return mapper.Map<UserDTO>(dbUser);
        }

        public async Task<bool> DeleteUser(int Id)
        {
            var dbUser=await context.Users.Where(u => u.Id == Id).FirstOrDefaultAsync();
            if (dbUser == null)
                throw new Exception("Kullanıcı Bulunamadı");

            context.Users.Remove(dbUser);
            int result= await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<UserDTO> GetUserById(int Id)
        {
            return await context.Users
                                .Where(x => x.Id==Id)
                                .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                                .FirstOrDefaultAsync();
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await context.Users
                                .Where(x => x.IsActive)
                                .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                                .ToListAsync();
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            var dbUser = await context.Users.Where(u => u.Id == user.Id).FirstOrDefaultAsync();
            if (dbUser == null)
                throw new Exception("İlgili kayıt bulunamadı");


            mapper.Map(user, dbUser);

            int result = await context.SaveChangesAsync();

            return mapper.Map<UserDTO>(dbUser);
        }
    }
}
