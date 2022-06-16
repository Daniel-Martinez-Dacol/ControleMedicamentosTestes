using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.ModuloMedicamento
{
    public class ValidadorMedicamento : AbstractValidator<Medicamento>
    {
        public ValidadorMedicamento()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty();

            RuleFor(x => x.Descricao)
                .NotNull().NotEmpty();

            RuleFor(x => x.Lote)
                .NotNull().NotEmpty();

            RuleFor(x => x.Validade)
                .NotEqual(DateTime.MinValue)
                .WithMessage("A Validade é obrigatória!");

            RuleFor(x => x.QuantidadeDisponivel)
                .GreaterThan(0)
                .WithMessage("Quantidade de medicamentos deve ser maior que zero!");

            RuleFor(x => x.Fornecedor)
                .NotNull().NotEmpty();
        }
    }
}
