using System.Collections.Generic;

namespace SF.Services.Models.Bands
{
    public class UpdateBandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<int> GenreIdsToAdd { get; set; }
        public IList<int> GenreIdsToRemove { get; set; }
    }
}
