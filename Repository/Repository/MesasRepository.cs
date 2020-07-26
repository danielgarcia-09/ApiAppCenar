using AutoMapper;
using Database.Models;
using DTOS;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class MesasRepository : RepositoryBase<Mesas,ApiCenarContext>
    {
        private readonly IMapper _mapper;
        private readonly ApiCenarContext _context;
        private readonly OrdenesRepository _repository;
        public MesasRepository(ApiCenarContext context, IMapper mapper, OrdenesRepository repository) : base(context)
        {
            _mapper = mapper;
            _context = context;
            _repository = repository;
        }

        public async Task<List<MesasDTO>> GetAllDto()
        {
            var list = await getAll();
            var dtoList = new List<MesasDTO>();

            foreach (var item in list)
            {
                var dto = new MesasDTO
                {
                    Id = item.Id,
                    Estado = item.Estado,
                    CantidadPersonas = item.CantidadPersonas,
                    Descripcion = item.Descripcion
                };
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public async Task<bool> UpdateOrd(int id, Mesas entity)
        {
            try
            {
                var mesas = await getById(id);
                var dto = new MesasDTO
                {
                    Id = mesas.Id,
                    Estado = mesas.Estado,
                    CantidadPersonas = entity.CantidadPersonas,
                    Descripcion = entity.Descripcion
                };
                var update = _mapper.Map(dto, mesas);
                await Update(update);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> Status(int id, Mesas entity)
        {
            try
            {
                var mesas = await getById(id);
                var dto = new MesasDTO
                {
                    Id = mesas.Id,
                    Estado = entity.Estado,
                    CantidadPersonas = mesas.CantidadPersonas,
                    Descripcion = mesas.Descripcion
                };
                var update = _mapper.Map(dto, mesas);
                await Update(update);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<List<OrdenesDTO>> GetOrders(int id)
        {
            var list = _context.Ordenes.Where(e => e.MesaId == id).ToList();
            var dtoList = new List<OrdenesDTO>();
            foreach(var item in list)
            {
                var dto = new OrdenesDTO
                {
                    Id = item.Id,
                    Estado = item.Estado,
                    PlatosSeleccionados = item.PlatosSeleccionados,
                    MesaId = item.MesaId,
                    SubTotal = item.SubTotal
                };
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public async Task<bool> Complete(int id)
        {
            try
            {
                var ordenes = _context.Ordenes.Where(e => e.MesaId == id).ToList();
                var subtotal = 0;
                var precio = 0;
                foreach(var item in ordenes)
                {
                    var arr = item.PlatosSeleccionados.Split(",");
                    
                    for(var i = 0; i < arr.Length; i++)
                    {
                        precio = _context.Platos.Where(c => c.Nombre.Contains(arr[i])).Select(s => s.Precio).Sum();
                        subtotal += precio;
                    }
                    
                }
                
            
                foreach(var item in ordenes)
                {
                    item.Estado = "Completado";
                    item.SubTotal = subtotal;
                }
                await _repository.UpdateRange(ordenes);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
