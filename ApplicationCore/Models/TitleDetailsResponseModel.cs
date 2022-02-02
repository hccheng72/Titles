using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class TitleDetailsResponseModel
    {
        public TitleDetailsResponseModel()
        {
            StoryLines = new List<StoryLineResponseModel>();
            Genres = new List<GenreResponseModel>();
            Awards = new List<AwardResponseModel>();
        }
        public int TitleId { get; set; }
        public string? TitleName { get; set; }
        public int? ReleaseYear { get; set; }
        public List<StoryLineResponseModel> StoryLines { get; set; }
        public List<GenreResponseModel> Genres { get; set; }
        public List<AwardResponseModel> Awards { get; set; }
    }
}
