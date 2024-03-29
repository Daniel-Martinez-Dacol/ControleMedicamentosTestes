﻿using ControleMedicamentos.Dominio.ModuloRequisicao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Tests.ModuloRequisicao
{
    [TestClass]
    public class ValidadorRequisicaoTest
    {
        public ValidadorRequisicaoTest()
        {
        }

        [TestMethod]
        public void QuantidadeMedicamento_deve_ser_maior_que_0()
        {
            var requisicao = new Requisicao();
            requisicao.QtdMedicamento = -1;

            ValidadorRequisicao validador = new ValidadorRequisicao();

            var resultado = validador.Validate(requisicao);

            Assert.AreEqual(false, resultado.IsValid);
        }
    }
}
