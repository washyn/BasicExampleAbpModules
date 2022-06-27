using System.Threading.Tasks;

namespace WebApplicationMvc.Services
{
    public interface IViewRenderService
    {
        Task<string> RederToStringAsync<TModel>(string viewName, TModel model);
    }
}