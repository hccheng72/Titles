using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class AwardResponseModel
    {
        public int Id { get; set; }
        public bool? AwardWon { get; set; }
        public string? Award1 { get; set; }
        public string? AwardCompany { get; set; }
    }
}
