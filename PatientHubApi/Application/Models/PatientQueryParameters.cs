
namespace PatientHubApi.Application.Models;

public class PatientQueryParameters
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Name { get; set; }
    public string? DocumentNumber { get; set; }
}
