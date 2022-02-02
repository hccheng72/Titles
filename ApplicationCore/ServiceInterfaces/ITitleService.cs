using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ITitleService
    {
        Task<IEnumerable<TitleCardResponseModel>> GetAllTitles();
        Task<TitleDetailsResponseModel> GetDetailsById(int id);
        Task<IEnumerable<TitleCardResponseModel>> SearchByTitleName(string titleName);
    }
}
