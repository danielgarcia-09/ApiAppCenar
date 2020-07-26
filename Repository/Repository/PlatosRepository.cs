using AutoMapper;
using Database.Models;
using DTOS;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PlatosRepository : RepositoryBase<Platos, ApiCenarContext>
    {
        private readonly IMapper _mapper;
        public PlatosRepository(ApiCenarContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<PlatosDTO>> GetAllDto()
        {
            var list = await getAll();
            var dtoList = new List<PlatosDTO>();

            foreach(var item in list)
            {
                var dto = new PlatosDTO
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Precio = item.Precio,
                    Categoria = item.Categoria,
                    CantidadPersonas = item.CantidadPersonas,
                    Ingredientes = item.Ingredientes
                };
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public async Task<bool> UpdatePlt(int id, Platos entity)
        {
            try
            {
                var platos = await getById(id);
                var dto = new PlatosDTO
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    CantidadPersonas = entity.CantidadPersonas,
                    Categoria = entity.Categoria,
                    Ingredientes = entity.Ingredientes,
                    Precio = entity.Precio
                };
                var update = _mapper.Map(dto, platos);
                await Update(update);
                return true;
            }
            catch (Exception )
            {
                return false;
            }

        }
    }
}
