using Capirchio_BlockBuster;
using Capirchio_BlockBuster.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlockBusterWebApp.Helpers
{
    public static class DropDownFormatter
    {
        public static SelectList FormatDirectors()
        {
            return new SelectList(BlockBusterBasicFunctions.GetAllDirectors()
                .OrderBy(d => d.LastName)
                .ToDictionary(d => d.DirectorId, d => d.LastName + ", " + d.FirstName), "Key", "Value");
        }

        public static SelectList FormatGenres()
        {
            return new SelectList(BlockBusterBasicFunctions.GetAllGenres()
                .OrderBy(g => g.GenreDescr)
                .ToDictionary(g => g.GenreId, g => g.GenreDescr), "Key", "Value");
        }
    }

    
}
