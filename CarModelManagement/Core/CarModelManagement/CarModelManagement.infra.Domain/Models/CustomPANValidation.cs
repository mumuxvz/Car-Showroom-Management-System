using System.ComponentModel.DataAnnotations;

namespace CarModelManagement.infra.Domain.Models;

public class CustomPANValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {

        string pan = Convert.ToString(value);
        return pan.Length == 10;
    }
}
