using ControleMedicamentos.Dominio.ModuloFornecedor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Tests.ModuloFuncionario
{
    [TestClass]
    public class ValidadorFornecedorTest
    {
        public ValidadorFornecedorTest()
        {
            
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            var fornecedor = new Fornecedor();
            fornecedor.Nome = null;

            ValidadorFornecedor validador = new ValidadorFornecedor();

            var resultado = validador.Validate(fornecedor);

            Assert.AreEqual(false, resultado.IsValid);
        }

        [TestMethod]
        public void Telefone_deve_ser_obrigatorio()
        {
            var fornecedor = new Fornecedor();
            fornecedor.Nome = "Ciclano";
            fornecedor.Telefone = null;

            ValidadorFornecedor validador = new ValidadorFornecedor();

            var resultado = validador.Validate(fornecedor);

            Assert.AreEqual(false, resultado.IsValid);
        }

        [TestMethod]
        public void Email_deve_ser_obrigatorio()
        {
            var fornecedor = new Fornecedor();
            fornecedor.Nome = "Ciclano";
            fornecedor.Telefone = "123456789";
            fornecedor.Email = null;

            ValidadorFornecedor validador = new ValidadorFornecedor();

            var resultado = validador.Validate(fornecedor);

            Assert.AreEqual(false, resultado.IsValid);
        }

        [TestMethod]
        public void Cidade_deve_ser_obrigatoria()
        {
            var fornecedor = new Fornecedor();
            fornecedor.Nome = "Ciclano";
            fornecedor.Telefone = "123456789";
            fornecedor.Email = "ciclano@gmail.com";
            fornecedor.Cidade = null;

            ValidadorFornecedor validador = new ValidadorFornecedor();

            var resultado = validador.Validate(fornecedor);

            Assert.AreEqual(false, resultado.IsValid);
        }

        [TestMethod]
        public void Estado_deve_ser_obrigatorio()
        {
            var fornecedor = new Fornecedor();
            fornecedor.Nome = "Ciclano";
            fornecedor.Telefone = "123456789";
            fornecedor.Email = "ciclano@gmail.com";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = null;

            ValidadorFornecedor validador = new ValidadorFornecedor();

            var resultado = validador.Validate(fornecedor);

            Assert.AreEqual(false, resultado.IsValid);
        }

    }
}
