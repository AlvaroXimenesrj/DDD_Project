using System;

namespace Loja.ProjetoDDD.Domain.Entites
{
    public class Endereco
    {
        public Endereco()
        {
            EnderecoId = Guid.NewGuid();
        }

        public Guid EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        /*Para ele saber "de quem é" esse endereço já que terá uma relação
        1,n no banco*/
        public Guid ClienteId { get; set; }
        //abaixo, se tranformará na FK do BD
        public virtual Cliente Cliente { get; set; }

        

    }
}
