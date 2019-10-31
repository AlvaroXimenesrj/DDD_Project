using Loja.ProjetoDDD.Domain.Entites;
using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Infra.Data.EntityConfig.Dapper
{
    public class ClienteMap : EntityMap<Cliente>
    {
        public ClienteMap()
        {
            Map(c => c.CPF.Numero).ToColumn("CPF");
        }
    }
}
