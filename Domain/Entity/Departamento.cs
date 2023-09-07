using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;

namespace Domain.Entity
{
public class Departamento : Base
{
        public string NomeDepartamento { get; set; }
        public string NomeResponsavel { get; set; }

        public override bool Validate()
        {
          var validator = new DepartamentoValidator();
          var validation = validator.Validate(this);

           if (!validation.IsValid)
           {
             foreach (var error in validation.Errors)
               _errors.Add(error.ErrorMessage);

                    throw new DomainExceptions("Alguns campos estão invalidos, corrija-os", _errors);
           }
            return true;
        }
   }
}
