using Almacen_API.Models;
using System.Collections.Generic;

namespace Almacen_API.Contracts
{
    public interface IRopaRepository
    {
        List<Ropa> GetRopas();
        void AddArticle(Ropa ropa);
        void AddArticleStock(int id, int cantidad);
        void RemoveArticleStock(int id, int cantidad);
        void UpdateRopa(Ropa ropa);
    }
}
