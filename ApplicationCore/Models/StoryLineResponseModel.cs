using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class StoryLineResponseModel
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Language { get; set; }
        public string? Description { get; set; }
    }
}
