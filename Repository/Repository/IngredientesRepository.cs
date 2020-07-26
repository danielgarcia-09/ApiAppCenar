using AutoMapper;
using Database;
using Database.Models;
using DTOS;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class IngredientesRepository : RepositoryBase<Ingredientes, ApiCenarContext>
    {
        private readonly IMapper _mapper;
        public IngredientesRepository(ApiCenarContext context, IMapper mapper) : base(context)
        {
            _mapper= mapper;
        }
        public async Task<List<IngredientesDTO>> GetAllDto()
        {
            var list = await getAll();
            var dtoList = new List<IngredientesDTO>();

            foreach (var item in list)
            {
                var dto = new IngredientesDTO
                {
                    Id = item.Id,
                    Nombre = item.Nombre
                };
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public async Task<bool> UpdateIngr(int id, Ingredientes entity)
        {
            try
            {
                var ingrediente = await getById(id);
                var dto = new IngredientesDTO
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre
                };
                var update =_mapper.Map(dto,ingrediente);
                await Update(update);
                return true;
            }
            catch(Exception )
            {
                return false;
            }
            
        }
    }
}
