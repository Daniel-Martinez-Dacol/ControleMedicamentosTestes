using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamento.Infra.BancoDados.ModuloMedicamento;
using ControleMedicamentos.Infra.BancoDados.ModuloFornecedor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Infra.BancoDados;

namespace ControleMedicamento.Infra.BancoDados.Tests.ModuloMedicamento
{
    [TestClass]
    public class RepositorioMedicamentoEmBancoDeDadosTest
    {
        private Medicamento medicamento;
        private RepositorioMedicamentoEmBancoDados repositorioMedicamento;
        private Fornecedor fornecedor;
        private RepositorioFornecedorEmBancoDados repositorioFornecedor;

        public RepositorioMedicamentoEmBancoDeDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBMEDICAMENTO; DBCC CHECKIDENT (TBMEDICAMENTO, RESEED, 0)");
            Db.ExecutarSql("DELETE FROM TBFORNECEDOR; DBCC CHECKIDENT (TBFORNECEDOR, RESEED, 0)");

            medicamento = gerarMedicamento();
            fornecedor = gerarFornecedor();
            medicamento.Fornecedor = fornecedor;
            repositorioMedicamento = new RepositorioMedicamentoEmBancoDados();
            repositorioFornecedor = new RepositorioFornecedorEmBancoDados();
        }

        public Medicamento gerarMedicamento()
        {
            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "Leite com Manga";
            medicamento.Descricao = "Resolve tudo.";
            medicamento.Lote = "ABCD";
            medicamento.Validade = new DateTime(2022, 02, 12, 10, 00, 00);
            medicamento.QuantidadeDisponivel = 200;

            return medicamento;
        }

        public Fornecedor gerarFornecedor()
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Rogicleia";
            fornecedor.Email = "rogicleia@gmail.com";
            fornecedor.Telefone = "123456789";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "SC";

            return fornecedor;
        }

        [TestMethod]
        public void Deve_inserir_novo_medicamento()
        {
            repositorioFornecedor.Inserir(fornecedor);
            repositorioMedicamento.Inserir(medicamento);

            var medicamentoEncontrado = repositorioMedicamento.SelecionarPorNumero(medicamento.Id);

            Assert.IsNotNull(medicamentoEncontrado);
            Assert.AreEqual(medicamento, medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_medicamento()
        {
                     
            repositorioFornecedor.Inserir(fornecedor);
            repositorioMedicamento.Inserir(medicamento);


            medicamento.Nome = "Dorflex";
            medicamento.Descricao = "Para dores";
            repositorioMedicamento.Editar(medicamento);

            var medicamentoEncontrado = repositorioMedicamento.SelecionarPorNumero(medicamento.Id);

            Assert.IsNotNull(medicamentoEncontrado);
            Assert.AreEqual(medicamento, medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_medicamento()
        {        
            repositorioFornecedor.Inserir(fornecedor);
            repositorioMedicamento.Inserir(medicamento);
        
            repositorioMedicamento.Excluir(medicamento);

            var medicamentoEncontrado = repositorioMedicamento.SelecionarPorNumero(medicamento.Id);
            Assert.IsNull(medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_medicamento()
        {
        
            repositorioFornecedor.Inserir(fornecedor);
            repositorioMedicamento.Inserir(medicamento);


            var medicamentoEncontrado = repositorioMedicamento.SelecionarPorNumero(medicamento.Id);


            Assert.IsNotNull(medicamentoEncontrado);
            Assert.AreEqual(medicamento, medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_medicamentos()
        {
            repositorioFornecedor.Inserir(fornecedor);
            var medicamento1 = new Medicamento("Xanax",
                "Contra tudo e todos",
                "ABCD",
                new DateTime(2022, 02, 12, 10, 00, 00),
                22,
                fornecedor);
            var medicamento2 = new Medicamento("CoristinaD",
                "Contra dor e febre",
                "ABCD",
                new DateTime(2022, 02, 12, 10, 00, 00),
                30,
                fornecedor);

            repositorioMedicamento.Inserir(medicamento1);
            repositorioMedicamento.Inserir(medicamento2);

            var medicamentos = repositorioMedicamento.SelecionarTodos();

            Assert.AreEqual(2, medicamentos.Count);

            Assert.AreEqual(medicamento1.Nome, medicamentos[0].Nome);
            Assert.AreEqual(medicamento2.Nome, medicamentos[1].Nome);

        }
    }
}
