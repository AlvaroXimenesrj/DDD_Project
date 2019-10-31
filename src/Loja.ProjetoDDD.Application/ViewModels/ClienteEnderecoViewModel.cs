using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Application.ViewModels
{
    public class ClienteEnderecoViewModel
    {
        /*abaixo, criar as classes que irão trafegar entre ambas para a View poder
         enxergar*/
        public ClienteViewModel ClienteViewModel { get; set; }
        public EnderecoViewModel EnderecoViewModel { get; set; }
    }
}
