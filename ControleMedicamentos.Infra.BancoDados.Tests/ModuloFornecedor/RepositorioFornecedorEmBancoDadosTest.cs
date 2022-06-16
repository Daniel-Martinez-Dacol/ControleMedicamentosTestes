using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Infra.BancoDados.ModuloFornecedor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.Tests.ModuloFornecedor
{
    [TestClass]
    public class RepositorioFornecedorEmBancoDadosTest
    {
        private Fornecedor fornecedor;
        private RepositorioFornecedorEmBancoDados repositorio;

        public RepositorioFornecedorEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBFORNECEDOR; DBCC CHECKIDENT (TBFORNECEDOR, RESEED, 0)");

            fornecedor = gerarFornecedor();
            repositorio = new RepositorioFornecedorEmBancoDados();
        }

        public Fornecedor gerarFornecedor()
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Rogerio";
            fornecedor.Email = "RogerinDoYoutube@gmail.com";
            fornecedor.Telefone = "4002-8922";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "SC";

            return fornecedor;
        }

        [TestMethod]
        public void Deve_inserir_novo_fornecedor()
        {
            //action
            repositorio.Inserir(fornecedor);

            //assert
            var fornecedorEncontrado = repositorio.SelecionarPorNumero(fornecedor.Id);

            Assert.IsNotNull(fornecedorEncontrado);
            Assert.AreEqual(fornecedor, fornecedorEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_fornecedor()
        {
            //arrange                      
            repositorio.Inserir(fornecedor);

            //action
            fornecedor.Nome = "Luciano";
            fornecedor.Telefone = "1234556679";
            fornecedor.Email = "LucianoDoYoutube@gmail.com";
            fornecedor.Cidade = "Indaiatuba";
            fornecedor.Estado = "SP";

            repositorio.Editar(fornecedor);

            //assert
            var fornecedorEncontrado = repositorio.SelecionarPorNumero(fornecedor.Id);

            Assert.IsNotNull(fornecedorEncontrado);
            Assert.AreEqual(fornecedor, fornecedorEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_fornecedor()
        {
            //arrange           
            repositorio.Inserir(fornecedor);

            //action           
            repositorio.Excluir(fornecedor);

            //assert
            var fornecedorEncontrado = repositorio.SelecionarPorNumero(fornecedor.Id);
            Assert.IsNull(fornecedorEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_fornecedor()
        {         
            repositorio.Inserir(fornecedor);

            var fornecedorEncontrado = repositorio.SelecionarPorNumero(fornecedor.Id);

            Assert.IsNotNull(fornecedorEncontrado);
            Assert.AreEqual(fornecedor, fornecedorEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_fornecedores()
        {

            var fornecedor1 = new Fornecedor("Remedios daQui", "42006900", "daqui@gmail.com", "Lages", "SC");
            var fornecedor2 = new Fornecedor("Remedios deLá", "12345678", "dela@gmail.com", "Belo Horizonte", "MG");
            var fornecedor3 = new Fornecedor("Farmacia Corinthias", "87654321", "FarmaCorinthias@gmail.com", "São Paulo", "SP");

            var repositorio = new RepositorioFornecedorEmBancoDados();
            repositorio.Inserir(fornecedor1);
            repositorio.Inserir(fornecedor2);
            repositorio.Inserir(fornecedor3);

            var fornecedores = repositorio.SelecionarTodos();

            Assert.AreEqual(3, fornecedores.Count);

            Assert.AreEqual(fornecedor1.Nome, fornecedores[0].Nome);
            Assert.AreEqual(fornecedor2.Nome, fornecedores[1].Nome);
            Assert.AreEqual(fornecedor3.Nome, fornecedores[2].Nome);
        }
    }
}
