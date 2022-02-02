using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class TitleGenre
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; } = null!;
        public virtual Title Title { get; set; } = null!;
    }
}
