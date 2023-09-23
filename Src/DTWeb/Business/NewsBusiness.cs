using DTWeb.Models;

namespace DTWeb.Business
{
    public class NewsBusiness : INewsBusiness
    {
        public NewsModel GetBySlug(string slug)
        {
            return new NewsModel()
            {
                Id = 1,
                Content = "Test Slug"
            };
        }
    }
}