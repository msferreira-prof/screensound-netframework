using System;
using MySql.Data.MySqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
	public class Connection
	{

		private string connectionString = "Server=localhost; Port=8889; Uid=root;" +
                                          "Pwd=root@123456; Database=screensound";

		public Connection()
		{
		}

		public MySqlConnection ObterConexao()
		{
			return new MySqlConnection(connectionString);
		}

        public IEnumerable<Artista> Listar()
		{
			var lista = new List<Artista>();
			using MySqlConnection connection = ObterConexao();
			connection.Open();

			string sql = "SELECT * FROM ARTISTAS";
			MySqlCommand command = new MySqlCommand(sql, connection);
			using MySqlDataReader dataReader = command.ExecuteReader();

			while (dataReader.Read())
			{
				string nomeArtista = Convert.ToString(dataReader["Nome"]);
				string bioArtista = Convert.ToString(dataReader["Bio"]);
				int idArtista = Convert.ToInt32(dataReader["Id"]);

                Artista artista = new(nomeArtista, bioArtista) 
                {
                    Id = idArtista
                };

				lista.Add(artista);

            }

			return lista;
		}
	}
}

