using Loja.ProjetoDDD.Domain.Entites;
using Loja.ProjetoDDD.Domain.Value_Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Domain.Tests.Entity
{
    [TestClass]
    public class ClienteTests
    {
        //AA => Arrange, Act, Assert
        
        [TestMethod]
        public void Cliente_SelfValidation_IsValid()
        {
            var cliente = new Cliente()
            {
                CPF = new CPF() { Numero = "30390600822" },
                Email = new Email() { endereco = "cliente@cliente.com"},
                DataNascimento = new DateTime(1980,01,01)
            };

            var result = cliente.EhValido();

            Assert.IsTrue(result);

        }
        [TestMethod]
        public void Cliente_SelfValidation_IsNotValid()
        {
            var cliente = new Cliente()
            { //abaixo você não saberá qual falhou??
                CPF = new CPF() { Numero = "30390600821" },
                Email = new Email() { endereco = "cliente2cliente.com" },
                DataNascimento = new DateTime(2009,01,01)
            };

            var result = cliente.EhValido();

            Assert.IsFalse(result);
            //abaixo, a string da mensagem deve estar identica a que você colocou nas Specification na Domain!!!!!!!!!
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um CPF inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um e-mail inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente não é maior de idade."));

        }
    }
}
