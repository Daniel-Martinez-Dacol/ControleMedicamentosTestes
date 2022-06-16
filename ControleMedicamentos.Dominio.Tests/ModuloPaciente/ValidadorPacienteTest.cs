using ControleMedicamentos.Dominio.ModuloPaciente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Tests.ModuloPaciente
{
    [TestClass]
    public class ValidadorPacienteTest
    {
        public ValidadorPacienteTest()
        {
        }

        [TestMethod]
        public void Nome_do_paciente_deve_ser_obrigatorio()
        {
            var paciente = new Paciente();
            paciente.Nome = null;

            ValidadorPaciente validador = new ValidadorPaciente();

            var resultado = validador.Validate(paciente);

            Assert.AreEqual(false, resultado.IsValid);
        }

        [TestMethod]
        public void CartaoSUS_do_paciente_deve_ser_obrigatorio()
        {
            var p = new Paciente();
            p.Nome = "Cleitin";
            p.CartaoSUS = null;

            ValidadorPaciente validador = new ValidadorPaciente();

            var resultado = validador.Validate(p);

            Assert.AreEqual(false, resultado.IsValid);
        }

    }
}
