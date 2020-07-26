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
    public class OrdenesRepository : RepositoryBase<Ordenes,ApiCenarContext>
    {
        private readonly IMapper _mapper;
        private readonly ApiCenarContext _context;
        public OrdenesRepository(ApiCenarContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        
        public async Task<List<OrdenesDTO>> GetAllDto()
        {
            var list = await getAll();
            var dtoList = new List<OrdenesDTO>();

            foreach(var item in list)
            {
                var dto = new OrdenesDTO
                {
                    Id = item.Id,
                    Estado = item.Estado,
                    MesaId = item.MesaId,
                    PlatosSeleccionados = item.PlatosSeleccionados,
                    SubTotal = item.SubTotal
                };
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public async Task<bool> UpdateOrd(int id, Ordenes entity)
        {
            try
            {
                var orden = await getById(id);
                var dto = new OrdenesDTO
                {
                    Id = orden.Id,
                    Estado = orden.Estado,
                    MesaId = orden.MesaId,
                    PlatosSeleccionados = entity.PlatosSeleccionados,
                    SubTotal = orden.SubTotal
                };
                var update = _mapper.Map(dto, orden);
                await Update(update);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> UpdateRange(List<Ordenes> ordenes)
        {
            if(ordenes.Count == 0)
            {
                return false;
            }
            else
            {
                _context.UpdateRange(ordenes);
                await _context.SaveChangesAsync();
                return true;
            }
           
        }

    }
}
