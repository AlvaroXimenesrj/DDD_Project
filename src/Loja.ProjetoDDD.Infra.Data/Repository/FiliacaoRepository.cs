using Dapper;
using Loja.ProjetoDDD.Domain.Entites;
using Loja.ProjetoDDD.Domain.Repository;
using Loja.ProjetoDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Infra.Data.Repository
{
    public class FiliacaoRepository : Repository<Cliente>, IFiliacaoRepository
    {
        //após o unitof work

            public FiliacaoRepository(ProjetoDDDContext context)
            :base(context)
        {

        }

        /*Como na classe Repository eu declarei como protected, qualquer classe
         que herdá-la, pode usá-la*/

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF.Numero == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email.endereco == email).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterAtivos()

        {
            return Buscar(c => c.Ativo);
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Ativo = false;
            Atualizar(cliente);

        }


        
        //public override IEnumerable<Cliente> ObterTodos()
        //{
        //    /*vou criar uma query pegando carona com a conexão do ef*/
        //    //abrindo a conexão do EF
        //    var cn = Db.Database.Connection;
        //    /*agora vou criar a query*/
        //    var sql = "SELECT * FROM Sistema.Clientes";

        //    return cn.Query<Cliente>(sql);


        //}

        ////exemplo de Dapper agora com um LEFT JOIN:

        //public override Cliente ObterPorId(Guid id)
        //{
        //    var cn = Db.Database.Connection;

        //    var sql = @"SELECT * FROM Sistema.Clientes c " +
        //        "LEFT JOIN Sistema.Enderecos e " +
        //        "ON c.ClienteId = e.ClienteId " +
        //        "WHERE c.ClienteId = @sid";
        //    /*var cliente quero fazer uma query onde quero trabalhar com endreco
        //     e cliente e retornando o Cliente (linha 66) e ai
        //     faço uma expresso c e e onde c add 3 e retorna cliente onde o
        //     sid é igual ao id que recebi e a chave primária é cliendId e EnderecoId
        //     e por fim retornando first ou default*/
        //    var cliente = cn.Query<Cliente, Endereco, Cliente>(sql,
        //        (c, e) =>
        //        {
        //            c.Enderecos.Add(e);
        //            return c;
        //        }, new { sid = id }, splitOn: "ClienteId, EnderecoId");


        //    // throw new Exception("THE TRETA PLANTADA!!!!!!!!!!!!!!!!!");
        //    return cliente.FirstOrDefault();
        //}


    }
}
