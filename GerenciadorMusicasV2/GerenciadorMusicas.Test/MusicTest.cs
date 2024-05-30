using GerenciadorMusicas.Model;
using GerenciadorMusicas.Utilities;
using System.Xml.Linq;

namespace GerenciadorMusicas.Test
{
    public class MusicTest
    {
        [Theory]
        [InlineData("Chora, Me Liga", "João Bosco & Vinícius", true, "")]
        [InlineData(null, "Maiquinho Jadson", false, "A música não possui nome válido.")]
        public void ReturnMusicValidWhenNameIsValid(string name, string artist, bool validation, string errorMessage)
        {
            var music = new Music(name, artist);

            Assert.Equal(validation, music.IsValid);
            Assert.Contains(errorMessage, music.Errors.Summary);
        }

        [Theory]
        [InlineData("Billie Jean", "Maiquinho Jadson", true)]
        [InlineData("Billie Jean", null, false)]
        [InlineData("Billie Jean", "", false)]
        [InlineData(null, "Maiquinho Jadson", false)]
        [InlineData("", "Maiquinho Jadson", false)]
        [InlineData("", "", false)]
        [InlineData(null, null, false)]
        public void ReturnMusicIdValidWhenLoadMusicConstructor(string name, string artist, bool validation)
        {
            var music = new Music(name, artist);

            Assert.True(UUIDGenerator.IsValidUUID(music.Id));
            Assert.Equal(validation, music.IsValid);
        }

        [Theory]
        [InlineData("Balada Boa", "Gusttavo Lima", "d3f29d60-6a3c-4b0c-a1d3-5dfd3e18aacf", "Id: d3f29d60-6a3c-4b0c-a1d3-5dfd3e18aacf Nome: Balada Boa")]
        [InlineData("", "Maiquinho Jadson", "d3f29d60-6a3c-4b0c-a1d3-5dfd3e18aacf", "Id: d3f29d60-6a3c-4b0c-a1d3-5dfd3e18aacf Nome: ")]
        public void ReturnMusicStringValidWhenLoadStringMethod(string name, string artist, string idStr, string musicString)
        {
            var music = new Music(Guid.Parse(idStr), name, artist);

            Assert.Equal(musicString, music.ToString());
        }
    }
}
