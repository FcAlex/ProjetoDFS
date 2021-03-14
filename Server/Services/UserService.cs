using Server.Domains.Models;
using Server.Domains.Repositories;
using Server.Domains.Services;
using Server.Domains.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> ListAllAsync() => await _userRepository.ListAllAsync();

        public async Task<User> FindByIdAsync(int id) => await _userRepository.FindByIdAsync(id);

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occorred when saving the user: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("User not found");
            

            user.CopyTo(existingUser);

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when updating the user: {ex.Message}");
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("User not found");

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occorred when deleting the user: {ex.Message}");
            }
        }
    }
}
