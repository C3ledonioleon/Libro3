using FluentValidation;
using NetflixLibrosRazor.Models;

public class LibroValidator : AbstractValidator<LibroCreateDto>
{
    public LibroValidator()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty().WithMessage("El título es obligatorio")
            .MaximumLength(200).WithMessage("El título es demasiado largo");

        RuleFor(x => x.Autor)
            .NotEmpty().WithMessage("Debe ingresar un autor");

        RuleFor(x => x.Genero)
            .NotEmpty().WithMessage("Debe especificar un género");

    }
}

public class LibroUpdateValidator : AbstractValidator<LibroUpdateDto>
{
    public LibroUpdateValidator()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty().WithMessage("El título es obligatorio")
            .MaximumLength(200).WithMessage("El título es demasiado largo");

        RuleFor(x => x.Autor)
            .NotEmpty().WithMessage("Debe ingresar un autor");

        RuleFor(x => x.Genero)
            .NotEmpty().WithMessage("Debe especificar un género");


    }
}