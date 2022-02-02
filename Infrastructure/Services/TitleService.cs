using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository _titleRepository;
        public TitleService(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public async Task<IEnumerable<TitleCardResponseModel>> GetAllTitles()
        {
            var titles = await _titleRepository.GetAll();
            var titleCards = new List<TitleCardResponseModel>();
            foreach (var title in titles)
            {
                titleCards.Add(
                    new TitleCardResponseModel { TitleId = title.TitleId, TitleName = title.TitleName }
                    );
            }
            return titleCards;
        }

        public async Task<TitleDetailsResponseModel> GetDetailsById(int id)
        {
            var title = await _titleRepository.GetById(id);
            var titleDetails = new TitleDetailsResponseModel
            {
                TitleId = title.TitleId,
                TitleName = title.TitleName,
                ReleaseYear = title.ReleaseYear,
            };

            foreach (var storyLine in title.StoryLines)
            {
                titleDetails.StoryLines.Add(new StoryLineResponseModel 
                { 
                    Id = storyLine.Id,
                    Type = storyLine.Type,
                    Language = storyLine.Language,
                    Description = storyLine.Description
                });
            }

            foreach (var tg in title.TitleGenres)
            {
                titleDetails.Genres.Add(new GenreResponseModel
                {
                    Id = tg.GenreId,
                    Name = tg.Genre.Name
                });
            }

            foreach (var award in title.Awards)
            {
                titleDetails.Awards.Add(new AwardResponseModel
                {
                    Id = award.Id,
                    AwardWon = award.AwardWon,
                    Award1 = award.Award1,
                    AwardCompany = award.AwardCompany
                });
            }

            return titleDetails;
        }

        public async Task<IEnumerable<TitleCardResponseModel>> SearchByTitleName(string titleName)
        {
            var titles = await _titleRepository.GetByName(titleName);
            var titleCards = new List<TitleCardResponseModel>();
            foreach (var title in titles)
            {
                titleCards.Add(
                    new TitleCardResponseModel { TitleId = title.TitleId, TitleName = title.TitleName }
                    );
            }
            return titleCards;
        }
    }
}
