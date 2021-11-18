using AspNetCoreApiIOC.Dal.Interfaces;
using AspNetCoreApiIOC.Ent;
using AspNetCoreApiIOC.VM;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreApiIOC.Dal.Implement
{
    public class UsuarioDal:Repository<UsuarioEnt,UsuarioVM>, IUsuarioDal
    {
        private IConfiguration config;
        public UsuarioDal(DataContext dc, IConfiguration Configuration):base(dc)
        {
            config = Configuration;
        }
        public async Task<IEnumerable<UsuarioVM>> ListaUsuario()
        {
            try
            {

                var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
                optionsBuilder.UseSqlServer(this.config.GetConnectionString("ModelDev"));

                DataContext dbContext = new DataContext(optionsBuilder.Options);

                var ret1 = dbContext.Usuario.ToListAsync();

                var ret = await _dataContext.Usuario.ToListAsync();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UsuarioEnt, UsuarioVM>();
                });

                IMapper iMapper = config.CreateMapper();

                List<UsuarioVM> vm = iMapper.Map<List<UsuarioVM>>(ret);

                return vm;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UsuarioVM>> ListaUsuarioPorPerfil(int idPerfil)
        { 
            return new List<UsuarioVM>();
        }

        public async Task<SistemaPerfilVM> AddSistemaPerfil(SistemaPerfilVM sistemaPerfil)
        {
            try
            {

                var v = await RetornaPerfilPorSistema(1);

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SistemaPerfilVM, SistemaPerfilEnt>();
                    cfg.CreateMap<PerfilVM, PerfilEnt>();
                    cfg.CreateMap<SistemaVM, SistemaEnt>();
                });

                IMapper iMapper = config.CreateMapper();

                SistemaPerfilEnt ent = iMapper.Map<SistemaPerfilEnt>(sistemaPerfil);

                await _dataContext.SistemaPerfil.AddAsync(ent);

                await _dataContext.SaveChangesAsync();

                config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SistemaPerfilEnt, SistemaPerfilVM>();
                    cfg.CreateMap<PerfilEnt, PerfilVM>();
                    cfg.CreateMap<SistemaEnt, SistemaVM>();
                });

                iMapper = config.CreateMapper();

                sistemaPerfil =  iMapper.Map<SistemaPerfilVM>(ent);

                return sistemaPerfil;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<IEnumerable<SistemaPerfilVM>> RetornaPerfilPorSistema(int idSistema)
        {
            try
            {


                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SistemaPerfilEnt, SistemaPerfilVM>();
                    cfg.CreateMap<PerfilEnt, PerfilVM>();
                    cfg.CreateMap<SistemaEnt, SistemaVM>();
                });

                IMapper iMapper = config.CreateMapper();

                var ret = await _dataContext.SistemaPerfil
                                .Where(x => x.IdSistema == idSistema)
                                .Include(x=> x.Perfil)
                                .Include(x=> x.Sistema)
                                .ToListAsync();

                var retorno = iMapper.Map<List<SistemaPerfilVM>>(ret);

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
