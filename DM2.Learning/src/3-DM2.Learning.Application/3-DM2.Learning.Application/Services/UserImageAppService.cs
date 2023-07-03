using _3_DM2.Learning.Application.Interfaces;
using _3_DM2.Learning.Application.ViewModels;
using _4_DM2.Learning.Domain.Entities;
using _4_DM2.Learning.Domain.Interfaces.Repositories;
using AutoMapper;

namespace _3_DM2.Learning.Application.Services
{
    public class UserImageAppService : IUserImageAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserImageRepository _repository;

        public UserImageAppService(IUserImageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Update(UserImageViewModel userImageViewModel)
        {
            var userImage = _mapper.Map<UserImage>(userImageViewModel);

            if (userImage.Id == Guid.Empty)
                await _repository.Create(userImage);

            await _repository.Update(userImage);

            return;
        }

        public async Task Remove(Guid id)
        {
            await _repository.Remove(id);

            return;
        }

    }
}
