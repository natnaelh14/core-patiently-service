using FluentValidation;
using PatientlyService.Core.Models.Tenant;

namespace PatientlyService.Core.Validators;

public class GetAllMoviesOptionsValidator : AbstractValidator<GetAllTenantsOptions>
{
    private static readonly string[] AcceptableSortFields =
    {
        "title", "yearofrelease"
    };
    
    public GetAllMoviesOptionsValidator()
    {
        RuleFor(x => x.SortField)
            .Must(x => x is null || AcceptableSortFields.Contains(x, StringComparer.OrdinalIgnoreCase))
            .WithMessage("You can only sort by 'title' or 'yearofrelease'");
    }
}
