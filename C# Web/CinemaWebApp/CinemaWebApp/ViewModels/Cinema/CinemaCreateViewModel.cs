using System.ComponentModel.DataAnnotations;
using static CinemaWebApp.Common.Constants.CinemaIndexViewConstants;
using static CinemaWebApp.Common.ErrorMessages.CinemaIndexViewErrorMessages;

namespace CinemaWebApp.ViewModels.Cinema;

public class CinemaCreateViewModel
{
    [Required(ErrorMessage = CinemaNameRequired)]
    [StringLength(CinemaNameMaxLength, ErrorMessage = CinemaNameTooLong)]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = LocationRequired)]
    [StringLength(LocationMaxLength, ErrorMessage = LocationTooLong)]
    public string Location { get; set; } = null!;
}