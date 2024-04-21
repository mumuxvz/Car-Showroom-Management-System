
using System.ComponentModel.DataAnnotations;

namespace CarModelManagement.infra.Domain.Models;

public class CustomGSTValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
       
        string gst = Convert.ToString(value);
        return gst.Length == 15;
    }
}