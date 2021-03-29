using System;
using System.Collections.Generic;
using Filmes.Series.Interfaces;

namespace Filmes.Series
{
	public class FilmeSerieRepositorio : IRepositorio<FilmeSerie>
	{
        private List<FilmeSerie> listaSerie = new List<FilmeSerie>();
		private List<FilmeSerie> listaFilme = new List<FilmeSerie>();
		public void Atualiza(int id, FilmeSerie objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(FilmeSerie objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<FilmeSerie> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public FilmeSerie RetornaPorId(int id)
		{
			return listaSerie[id];
		}
	}
}