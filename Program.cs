﻿using System;

namespace Filmes.Series
{
    class Program
    {
        static FilmeSerieRepositorio repositorio = new FilmeSerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = "C";

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						Inserir();
						Console.Clear();
						break;
					case "3":
						AtualizarSerie();
						Console.Clear();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = Menu();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net5.0
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net5.0
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			FilmeSerie atualizaSerie = new FilmeSerie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void Inserir()
		{
			Console.WriteLine("*** Inserir ***");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net5.0
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net5.0

			foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo que deseja incluir: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			FilmeSerie novaSerie = new FilmeSerie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string Menu()
		{
			//Console.Clear();
			Console.WriteLine();
			Console.WriteLine("Filmes e Séries a seu dispor!!!");

			Console.WriteLine("1- Listar");
			Console.WriteLine("2- Inserir");
			Console.WriteLine("3- Atualizar");
			Console.WriteLine("4- Excluir");
			Console.WriteLine("5- Visualizar");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			Console.Write("Informe a opção desejada: ");
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
