using System;
using System.Collections.Generic;
using Filmes.Series.Interfaces;

namespace Filmes.Series
{
	public class FilmeSerieRepositorio : IRepositorio<FilmeSerie>
	{
        private List<FilmeSerie> listaSerie = new List<FilmeSerie>();
		private List<FilmeSerie> listaFilme = new List<FilmeSerie>();
		public void Atualiza(int filme, int id, FilmeSerie objeto)
		{
			if (filme == 1) {
				listaFilme[id] = objeto;
			} else {
				listaSerie[id] = objeto;
			}
		}

		public void Exclui(int filme, int id)
		{
			if (filme == 1) {
				listaFilme[id].Excluir();
			} else {
				listaSerie[id].Excluir();
			};
		}

		public void Insere(int filme, FilmeSerie objeto)
		{
			if (filme == 1) {
				listaFilme.Add(objeto);
			} else {
				listaSerie.Add(objeto);
			}
		}

		public List<FilmeSerie> Lista(int filme)
		{
			if (filme == 1) {
				return listaFilme;
			} else {
				return listaSerie;
			}
		}

		public int ProximoId(int filme)
		{
			if (filme == 1) {
				return listaFilme.Count;
			} else {
				return listaSerie.Count;
			}
		}

		public FilmeSerie RetornaPorId(int filme, int id)
		{
			if (filme == 1) {
				return listaFilme[id];
			} else {
				return listaSerie[id];
			}
		}
	}
}