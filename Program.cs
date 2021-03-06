using System;

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
						Listar();
						break;
					case "2":
						Inserir();
						Console.Clear();
						break;
					case "3":
						Atualizar();
						Console.Clear();
						break;
					case "4":
						Excluir();
						break;
					case "5":
						Visualizar();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						Console.WriteLine("Opção inválida");
						break;
				}

				opcaoUsuario = Menu();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
        }

        private static void Excluir()
		{
			Console.WriteLine("*** Excluir ***");

			int entradaTipo = selecaoTipo();
			int indiceFilmeSerie = -1;

			Console.Write("Digite o id da série: ");
			try {
				indiceFilmeSerie = int.Parse(Console.ReadLine());	
			} catch {
				Console.WriteLine("Opção inválida.");
				return;
			}

			if ((indiceFilmeSerie < 0) | (indiceFilmeSerie >= repositorio.ProximoId(entradaTipo))) {
				Console.WriteLine("Opção inválida.");
				return;
			}

			repositorio.Exclui(entradaTipo, indiceFilmeSerie);
		}

        private static void Visualizar()
		{
			Console.WriteLine("*** Visualizar ***");

			int indiceFilmeSerie = -1;

			int entradaTipo = selecaoTipo();

			Console.Write("Digite o id do filme ou série: ");
			try {
				indiceFilmeSerie = int.Parse(Console.ReadLine());	
			} catch {
				Console.WriteLine("Opção inválida.");
				return;
			}

			if ((indiceFilmeSerie < 0) | (indiceFilmeSerie >= repositorio.ProximoId(entradaTipo))) {
				Console.WriteLine("Opção inválida.");
				return;
			}

			var serie = repositorio.RetornaPorId(entradaTipo, indiceFilmeSerie);

			Console.WriteLine(serie);
		}

        private static void Atualizar()
		{
			Console.WriteLine("*** Atualizar ***");

			int entradaTipo = selecaoTipo();
			int indice = -1;

			Console.Write("Digite o id correspondente: ");
			try {
				indice = int.Parse(Console.ReadLine());	
			} catch {
				Console.WriteLine("Opção inválida.");
				return;
			}

			if ((indice < 0) | (indice >= repositorio.ProximoId(entradaTipo))) {
				Console.WriteLine("Opção inválida.");
				return;
			}
			
            dadosFilmeSerie(out int entradaGenero, out int entradaAno, 
				out string entradaTitulo, out string entradaDescricao);
			
			FilmeSerie atualizaFilmeSerie = new FilmeSerie(id: indice,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(entradaTipo, indice, atualizaFilmeSerie);
		}
        private static void Listar()
		{
			Console.WriteLine("*** Listar ***");

			int entradaTipo = selecaoTipo();

			var lista = repositorio.Lista(entradaTipo);

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum cadastro.");
				return;
			}

			foreach (var filmeserie in lista)
			{
                var excluido = filmeserie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filmeserie.retornaId(), filmeserie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void Inserir()
        {
            Console.WriteLine("*** Inserir ***");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net5.0
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net5.0

            int entradaTipo = selecaoTipo();

            FilmeSerie novoFilmeSerie;
            dadosFilmeSerie(out int entradaGenero, out int entradaAno, 
				out string entradaTitulo, out string entradaDescricao);

			novoFilmeSerie = new FilmeSerie(id: repositorio.ProximoId(entradaTipo),
								genero: (Genero)entradaGenero,
								titulo: entradaTitulo,
								ano: entradaAno,
								descricao: entradaDescricao);

            repositorio.Insere(entradaTipo, novoFilmeSerie);
        }

        private static int selecaoTipo()
        {
            int entradaTipo;
			bool check = true;

			foreach (int i in Enum.GetValues(typeof(Tipo)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
            }
			
            Console.Write("Digite o tipo que deseja incluir: ");

			do {
				try {
					entradaTipo = int.Parse(Console.ReadLine());
				} catch (FormatException) {
					entradaTipo = 0;
				}
				check = (entradaTipo < 1) | (entradaTipo > Enum.GetValues(typeof(Tipo)).Length);
				if (check) {
					Console.WriteLine("Opção inválida. Por favor, entre com o valor dentro da faixa.");
				}
			} while (check);
            return entradaTipo;
        }

        private static void dadosFilmeSerie(out int entradaGenero, out int entradaAno, 
			out string entradaTitulo, out string entradaDescricao)
        {
			bool check;

			Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            
			do {
				entradaGenero = int.Parse(Console.ReadLine());
				check = (entradaGenero < 1) | (entradaGenero > Enum.GetValues(typeof(Genero)).Length);
				if (check) {
					Console.WriteLine("Valor inválido. Por favor, entre com o valor dentro da faixa.");
				}
			} while (check);
			
			Console.Write("Digite o Título: ");
            entradaTitulo = Console.ReadLine();
            Console.Write("Digite o Ano de Início: ");
			try {
				entradaAno = int.Parse(Console.ReadLine());
			} catch (FormatException) {
				Console.WriteLine("Ano inválido. Atribuindo ano padrão 1900.");
				entradaAno = 1900;
			}

			if ((entradaAno < 1850) | (entradaAno > DateTime.Now.Year)) {
				Console.WriteLine("Ano inválido. Atribuindo ano padrão 1900.");
				entradaAno = 1900;
			}
            Console.Write("Digite a Descrição: ");
            entradaDescricao = Console.ReadLine();
        }

        private static string Menu()
		{
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
