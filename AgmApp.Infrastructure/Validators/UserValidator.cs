using AgmApp.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgmApp.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
          //  RuleFor(user => user.UsrNombres).NotNull().Length(2, 7).WithMessage("El nombre de usuario debe tener 2 ~ 7 carácteres");
        }


    }
}
