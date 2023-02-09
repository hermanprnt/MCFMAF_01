using Microsoft.AspNetCore.Mvc.Rendering;

namespace MCFMAF_01.Models
{
    public class LocationDropdownViewModel
    {
        //public string LocationId { get; set; }
        //public string? LocationName { get; set; }
        public List<SelectListItem> LocationList { get; set; }
    }
}
