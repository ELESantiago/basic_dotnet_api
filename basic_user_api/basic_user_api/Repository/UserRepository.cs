using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using basic_user_api.Context;
using basic_user_api.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_user_api.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User toCreate)
        {
            try
            {
                await _context.User.AddAsync(toCreate);
                await _context.SaveChangesAsync();
                return toCreate;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int idToDelete)
        {
            try
            {
                var user = await Get(idToDelete);
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> Get(int id)
        {
            try
            {
                return await _context.User.SingleAsync(u => u.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await _context.User.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> Update(int id, User toUpdate)
        {
            try
            {
                var user = await Get(id);
                user.Name = toUpdate.Name;
                user.Username = toUpdate.Username;
                user.Email = toUpdate.Email;

                await _context.SaveChangesAsync();
                return user;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
