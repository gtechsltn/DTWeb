using DTWeb.Models;

namespace DTWeb.Business
{
    public interface INewsBusiness
    {
        NewsModel GetBySlug(string slug);
    }
}