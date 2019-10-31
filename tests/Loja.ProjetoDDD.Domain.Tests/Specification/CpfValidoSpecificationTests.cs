using Loja.ProjetoDDD.Domain.Entites;
using Loja.ProjetoDDD.Domain.Specification.Clientes;
using Loja.ProjetoDDD.Domain.Value_Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Domain.Tests.Specification
{
    [TestClass]
    public class CpfValidoSpecificationTests
    {
       [TestMethod]
        public void CPFSpecification_IsSatisfied_true()
        {
            var cliente = new Cliente()
            {
                CPF = new CPF() {  Numero = "30390600822"},
            };

            //Act
            var specReturn = new ClienteDeveTerCPFValidoSpecification().IsSatisfiedBy(cliente);
            //Assert
            Assert.IsTrue(specReturn);
        }
    }
}
