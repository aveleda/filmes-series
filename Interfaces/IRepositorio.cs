using System.Collections.Generic;

namespace Filmes.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista(int filme);
        T RetornaPorId(int filme, int id);        
        void Insere(int filme, T entidade);        
        void Exclui(int filme, int id);        
        void Atualiza(int filme, int id, T entidade);
        int ProximoId(int filme);
    }
}