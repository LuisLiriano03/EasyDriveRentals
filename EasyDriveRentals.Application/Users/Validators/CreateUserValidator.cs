using EasyDriveRentals.Application.Users.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Users.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {

            RuleFor(user => user.IdNumber)
                .NotEmpty().WithMessage("La cédula es requerida")
                .Length(11).WithMessage("La cédula debe tener exactamente 11 dígitos")
                .Matches(@"^\d{11}$").WithMessage("La cédula solo debe contener números");

            RuleFor(user => user.FullName)
               .NotEmpty().WithMessage("El nombre completo es requerido")
               .MaximumLength(50).WithMessage("El nombre completo no puede exceder los 50 caracteres");

            RuleFor(user => user.GenderId)
                .NotEmpty().WithMessage("El ID genero es requerido")
                .InclusiveBetween(1, 2).WithMessage("El genero debe estar entre 1 y 2");

            RuleFor(user => user.PhoneNumber)
                .NotEmpty().WithMessage("El numero de teléfono es requerido")
                .Matches(@"^[0-9]*$").WithMessage("El teléfono no acepta letras, solo números")
                .Length(10, 15).WithMessage("El teléfono debe tener entre 10 y 15 dígitos");


            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("El correo electrónico es requerido")
                .MaximumLength(100).WithMessage("El correo electrónico no puede exceder los 100 caracteres")
                .Must(email => email.EndsWith("@gmail.com") || email.EndsWith("@hotmail.com"))
                .WithMessage("El correo electrónico debe ser de tipo @gmail.com o @hotmail.com");


            RuleFor(user => user.PasswordHash)
                .NotEmpty().WithMessage("La contraseña es requerida")
                .MinimumLength(7).WithMessage("La contraseña debe tener al menos 7 caracteres")
                .MaximumLength(50).WithMessage("La contraseña no puede exceder los 50 caracteres");


            RuleFor(user => user.RolId)
                .NotEmpty().WithMessage("El ID del rol es requerido")
                .InclusiveBetween(1, 2).WithMessage("El rol debe estar entre 1 y 2");


        }

    }
}
