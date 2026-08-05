using Bingo.Application.Dtos.State;

namespace Bingo.Application.Dtos.Country;

public class CountryViewDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string IsoCode { get; set; }
    public string PhoneCode { get; set; }
    public IEnumerable<StateViewDto>? States { get; set; }
}