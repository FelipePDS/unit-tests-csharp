using GerenciadorMusicas.Model;
using GerenciadorMusicas.Utilities;
using System.Xml.Linq;

namespace GerenciadorMusicas.Test
{
    public class MusicTest
    {
        [Fact]
        public void MusicNameIsValid()
        {
            var music = new Music("Chora, Me Liga", "João Bosco & Vinícius");
            var musicWithoutArtist = new Music("Billie Jean", null);

            Assert.True(music.IsValid);
            Assert.True(!musicWithoutArtist.IsValid);
            Assert.DoesNotContain("A música não possui nome válido.", musicWithoutArtist.Errors.Summary);
        }

        [Fact]
        public void MusicIdIsValid()
        {
            var music = new Music("Billie Jean", "Maiquinho Jadson");

            Assert.True(UUIDGenerator.IsValidUUID(music.Id));
            Assert.True(music.IsValid);
        }

        [Fact]
        public void MusicStringIsValid()
        {
            var music = new Music("Balada Boa", "Gusttavo Lima");

            Assert.Equal(@$"Id: {music.Id} Nome: {music.Name}", music.ToString());
        }
    }
}
