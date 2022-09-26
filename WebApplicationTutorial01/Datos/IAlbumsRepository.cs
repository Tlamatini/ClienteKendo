using System.Linq.Expressions;

namespace WebApplicationTutorial01.Datos
{
    public interface IAlbumsRepository
    {
        IEnumerable<Album> GetAll();
    }
}
