using System.Data.SQLite;
using WebApplicationTutorial01.Datos;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplicationTutorial01.Datos
{
    public class AlbumsRepository : IAlbumsRepository
    {
        private readonly string _archivoBD;

        public AlbumsRepository()
        {
        }

        public AlbumsRepository(string archivoBD)
        {
            this._archivoBD = archivoBD;
        }

        public IEnumerable<Album> GetAll()
        {
            //Colocar la ruta correcta aqui.
            string rutaDb = @"URI=file:C:\Trabajo\Programacion\Sqlite\chinook\chinook.db";

            using (var con = new SQLiteConnection(rutaDb))
            {
                string stm = "SELECT AlbumId, Title FROM albums;";

                con.Open();

                using (var cmd = new SQLiteCommand(stm, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Album
                            {
                                AlbumId = reader.GetInt32(0),
                                Title = reader.GetString(1)
                            };
                        }
                    }
                }
            }
        }

        public void GetAll1()
        {
            //Colocar la ruta correcta aqui.
            string cs = @"URI=file:C:\Sqlite\chinook\chinook.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM albums;";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetInt32(2)}");
            }
        }
    }
}
