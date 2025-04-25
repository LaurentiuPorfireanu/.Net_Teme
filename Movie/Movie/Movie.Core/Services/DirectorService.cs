using Movie.Core.Dtos.Create;
using Movie.Core.Dtos.View;
using Movie.Core.Mapping;
using Movie.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Services
{
    public class DirectorService
    {
        private readonly DirectorRepository _repository;


        public DirectorService(DirectorRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<DirectorDto>> GetAllAsync()
        {
            var all= await _repository.GetAllAsync();
            return all.Select(DirectorMapper.ToDto).ToList();
        }

        public async Task AddAsync(CreateDirectorDto dto)
        {
            var entity = DirectorMapper.ToEntity(dto);
            _repository.Insert(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
