using GerenciadorMusicas.Utilities;
using JornadaMilhas.Model;

namespace GerenciadorMusicas.Model
{
    public class Music : Validator
    {
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
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }

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

            if (string.IsNullOrEmpty(Artist))
            {
                Errors.RegisterError("A música não possui artista válido.");
            }

            if (!UUIDGenerator.IsValidUUID(Id))
            {
                Errors.RegisterError("Identificador da música não inicializado corretamente.");
            }
        }
    }
}
