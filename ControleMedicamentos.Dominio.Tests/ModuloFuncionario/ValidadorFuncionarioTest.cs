using ControleMedicamentos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Tests.ModuloFuncionario
{
    [TestClass]
    public class ValidadorFuncionarioTest
    {
        public ValidadorFuncionarioTest()
        {
        }

        [TestMethod]
        public void Nome_do_funcionario_deve_ser_obrigatorio()
        {
            var f = new Funcionario();
            f.Nome = null;

            ValidadorFuncionario validador = new ValidadorFuncionario();

            var resultado = validador.Validate(f);

            Assert.AreEqual(false, resultado.IsValid);
        }

        [TestMethod]
        public void Login_do_funcionario_deve_ser_obrigatorio()
        {
            var funcionario = new Funcionario();
            funcionario.Nome = "Cara";
            funcionario.Login = null;

            ValidadorFuncionario validador = new ValidadorFuncionario();

            var resultado = validador.Validate(funcionario);

            Assert.AreEqual(false, resultado.IsValid);
        }

        [TestMethod]
        public void Senha_do_funcionario_deve_ser_obrigatorio()
        {
            var funcionario = new Funcionario();
            funcionario.Nome = "Cara";
            funcionario.Login = "abacaxi123";
            funcionario.Senha = null;

            ValidadorFuncionario validador = new ValidadorFuncionario();

            var resultado = validador.Validate(funcionario);

            Assert.AreEqual(false, resultado.IsValid);
        }

    }
}
