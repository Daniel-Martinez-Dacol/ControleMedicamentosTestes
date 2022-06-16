using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Infra.BancoDados.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.Tests.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioEmBancoDadosTest
    {
        private Funcionario funcionario;
        private RepositorioFuncionarioEmBancoDados repositorio;

        public RepositorioFuncionarioEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBFUNCIONARIO; DBCC CHECKIDENT (TBFUNCIONARIO, RESEED, 0)");

            funcionario = gerarFuncionario();
            repositorio = new RepositorioFuncionarioEmBancoDados();
        }

        public Funcionario gerarFuncionario()
        {
            Funcionario funcionario = new Funcionario();
            funcionario.Login = "logindefault";
            funcionario.Senha = "senhadefault";
            funcionario.Nome = "nomedefault";

            return funcionario;
        }

        [TestMethod]
        public void Deve_inserir_novo_funcionario()
        {

            repositorio.Inserir(funcionario);

            var funcionarioEncontrado = repositorio.SelecionarPorNumero(funcionario.Id);

            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_funcionario()
        {                      
            repositorio.Inserir(funcionario);

            funcionario.Nome = "Umcara";
            funcionario.Login = "Umlogin";
            funcionario.Senha = "Umasenha";
            repositorio.Editar(funcionario);

            var funcionarioEncontrado = repositorio.SelecionarPorNumero(funcionario.Id);

            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
        
            repositorio.Inserir(funcionario);
         
            repositorio.Excluir(funcionario);

            var funcionarioEncontrado = repositorio.SelecionarPorNumero(funcionario.Id);
            Assert.IsNull(funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_funcionario()
        {
        
            repositorio.Inserir(funcionario);

            var funcionarioEncontrado = repositorio.SelecionarPorNumero(funcionario.Id);

            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_funcionarios()
        {

            var funcionario1 = new Funcionario("Ree", "batata1", "sorvete123");
            var funcionario2 = new Funcionario("Aaa", "chiclete1", "abacaxicara");

            var repositorio = new RepositorioFuncionarioEmBancoDados();
            repositorio.Inserir(funcionario1);
            repositorio.Inserir(funcionario2);

            var funcionarios = repositorio.SelecionarTodos();

            Assert.AreEqual(2, funcionarios.Count);

            Assert.AreEqual(funcionario1.Nome, funcionarios[0].Nome);
            Assert.AreEqual(funcionario2.Nome, funcionarios[1].Nome);

        }
    }
}
