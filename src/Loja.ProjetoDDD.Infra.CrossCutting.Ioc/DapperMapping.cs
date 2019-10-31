using Dapper.FluentMap;
using Loja.ProjetoDDD.Infra.Data.EntityConfig.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Infra.CrossCutting.Ioc
{
    public class DapperMapping
    {

        public static void RegisterDapperMappings()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new ClienteMap());
            });
        }
    }
}
