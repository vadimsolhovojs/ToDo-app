using FluentValidation;
using TODO.Models;

namespace TODO.UseCases.Validations;

public class AddItemRequestValidator : AbstractValidator<AddItemRequest>
{
    public AddItemRequestValidator()
    {
        RuleFor(request => request.Title)
            .NotEmpty()
            .WithMessage("No title provided");
    }
}