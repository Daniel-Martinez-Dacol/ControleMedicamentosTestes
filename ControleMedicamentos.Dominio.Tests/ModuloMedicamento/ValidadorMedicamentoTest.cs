using ControleMedicamentos.Dominio.ModuloMedicamento;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Tests.ModuloMedicamento
{
    [TestClass]
    public class ValidadorMedicamentoTest
    {
        public ValidadorMedicamentoTest()
        {
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            var medicamento = new Medicamento();
            medicamento.Nome = null;

            ValidadorMedicamento validador = new ValidadorMedicamento();

            var resultado = validador.Validate(medicamento);

            Assert.AreEqual(false, resultado.IsValid);
        }

        [TestMethod]
        public void Descricao_deve_ser_obrigatoria()
        {
            var medicamento = new Medicamento();
            medicamento.Nome = "Fulano";
            medicamento.Descricao = null;

            ValidadorMedicamento validador = new ValidadorMedicamento();

            var resultado = validador.Validate(medicamento);

            Assert.AreEqual(false, resultado.IsValid);
        }

        [TestMethod]
        public void Lote_deve_ser_obrigatorio()
        {
            var medicamento = new Medicamento();
            medicamento.Nome = "Fulano";
            medicamento.Descricao = "medicamentos";
            medicamento.Lote = null;

            ValidadorMedicamento validador = new ValidadorMedicamento();

            var resultado = validador.Validate(medicamento);

            Assert.AreEqual(false, resultado.IsValid);
        }

        [TestMethod]
        public void Validade_deve_ser_obrigatoria()
        {
            var medicamento = new Medicamento();
            medicamento.Nome = "Fulano";
            medicamento.Descricao = "medicamentos";
            medicamento.Lote = "ABCD";
            medicamento.Validade = DateTime.MinValue;

            ValidadorMedicamento validador = new ValidadorMedicamento();

            var resultado = validador.Validate(medicamento);

            Assert.AreEqual(false, resultado.IsValid);
        }

        [TestMethod]
        public void QuantidadeDisponivel_deve_ser_maior_que_0()
        {
            var medicamento = new Medicamento();
            medicamento.Nome = "Fulano";
            medicamento.Descricao = "medicamentos";
            medicamento.Lote = "ABCD";
            medicamento.Validade = DateTime.Now;
            medicamento.QuantidadeDisponivel = -1;

            ValidadorMedicamento validador = new ValidadorMedicamento();

            var resultado = validador.Validate(medicamento);

            Assert.AreEqual(false, resultado.IsValid);
        }

        [TestMethod]
        public void Fornecedor_deve_ser_obrigatorio()
        {
            var medicamento = new Medicamento();
            medicamento.Nome = "Fulano";
            medicamento.Descricao = "medicamentos";
            medicamento.Lote = "ABCD";
            medicamento.Validade = DateTime.Now;
            medicamento.QuantidadeDisponivel = 200;
            medicamento.Fornecedor = null;

            ValidadorMedicamento validador = new ValidadorMedicamento();

            var resultado = validador.Validate(medicamento);

            Assert.AreEqual(false, resultado.IsValid);
        }

    }
}
