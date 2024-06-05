using GerenciadorMusicas.Utilities;
using JornadaMilhas.Model;

namespace GerenciadorMusicas.Model
{
    public class Music : Validator
    {
        private string _artist;
        private int? _releaseYear;

        public Music(string name, string artist)
        {
            Name = name;
            Artist = artist;
            Id = UUIDGenerator.GenerateUUID();

            Validate();
        }

        public Music(Guid id, string name, string artist)
        {
            Id = id;
            Name = name;
            Artist = artist;

            Validate();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Artist
        {
            get => _artist;
            set
            {
                _artist = string.IsNullOrEmpty(value) 
                    ? "Artista Desconhecido" 
                    : value;
            }
        }

        public int? ReleaseYear { 
            get => _releaseYear; 
            set
            {
                _releaseYear = value <= 0 ? null : value;
            }
        }

        public void ExibirFichaTecnica()
        {
            Console.WriteLine($"Nome: {Name}");
        }

        public override string ToString()
        {
            return @$"Id: {Id} Nome: {Name}";
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                Errors.RegisterError("A música não possui nome válido.");
            }

            if (!UUIDGenerator.IsValidUUID(Id))
            {
                Errors.RegisterError("Identificador da música não inicializado corretamente.");
            }
        }
    }
}
