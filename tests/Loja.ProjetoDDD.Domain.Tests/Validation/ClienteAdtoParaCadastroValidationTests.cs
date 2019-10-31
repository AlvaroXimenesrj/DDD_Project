using Loja.ProjetoDDD.Domain.Entites;
using Loja.ProjetoDDD.Domain.Repository;
using Loja.ProjetoDDD.Domain.Specification.Clientes;
using Loja.ProjetoDDD.Domain.Value_Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Domain.Tests.Validation
{   [TestClass]
    public class ClienteAdtoParaCadastroValidationTests
    {
        [TestMethod]
        public void ClienteApto_IsValid_True()
        {
            var cliente = new Cliente()
            { //abaixo você não saberá qual falhou??
                CPF = new CPF() { Numero = "30390600822" },
                Email = new Email() { endereco = "cliente2cliente.com" },
                
            };

            /*para ser apto deve ter um CPF e Email que não esteja registrado no banco
            Teste de unidade não depende de estrutura, entao ele não
            vai no banco, ele nao vai usar a connectionstring...
            ue.. e como pego informação do banco se nao posso ir la?
            entao é criar um MOC que é uma classe que finge fazer as coisas
            que as outras coisas fazem, ele finge que vai ao banco, para usar
            precisa usar um framework, tem o rinomox e outro(nao lembro)
            install-package rhinomocks*/

            //Act

            var repo = MockRepository.GenerateStub<IFiliacaoRepository>();
            repo.Stub(s => s.ObterPorCpf(cliente.CPF.Numero)).Return(null);
            /*acima, ele vai no banco, buscar o CPF e não achar nada! Ai significará*/
            repo.Stub(s => s.ObterPorEmail(cliente.Email.endereco)).Return(null);

            var validationReturn = new ClienteAptoParaCadastroValidation(repo)
                .Validate(cliente);

            //Assert

            Assert.IsTrue(validationReturn.IsValid);

        }
        [TestMethod]
        public void ClienteApto_IsValid_False()
        {
            var cliente = new Cliente()
            { //abaixo você não saberá qual falhou??
                CPF = new CPF() { Numero = "30390600822" },
                Email = new Email() { endereco = "cliente2cliente.com" },

            };

            /*para ser apto deve ter um CPF e Email que não esteja registrado no banco
            Teste de unidade não depende de estrutura, entao ele não
            vai no banco, ele nao vai usar a connectionstring...
            ue.. e como pego informação do banco se nao posso ir la?
            entao é criar um MOC que é uma classe que finge fazer as coisas
            que as outras coisas fazem, ele finge que vai ao banco, para usar
            precisa usar um framework, tem o rinomox e outro(nao lembro)
            install-package rhinomocks*/

            //Act

            var repo = MockRepository.GenerateStub<IFiliacaoRepository>();
            repo.Stub(s => s.ObterPorCpf(cliente.CPF.Numero)).Return(cliente);
            /*acima, ele vai no banco, buscar o CPF e não achar nada! Ai significará*/
            repo.Stub(s => s.ObterPorEmail(cliente.Email.endereco)).Return(cliente);

            var validationReturn = new ClienteAptoParaCadastroValidation(repo)
                .Validate(cliente);

            //Assert

            Assert.IsFalse(validationReturn.IsValid);

        }


    }
}
