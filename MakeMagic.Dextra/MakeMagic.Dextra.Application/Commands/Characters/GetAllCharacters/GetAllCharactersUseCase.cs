using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Application.Commands.Characters.GetAllCharacters
{
    /// <inheritdoc />
    public class GetAllCharactersUseCase : IGetAllCharactersUseCase
    {
        private readonly ICharacterRepository characterRepository;
        private bool disposedValue = false;
        public GetAllCharactersUseCase(
                ICharacterRepository characterRepository
            )
        {
            this.characterRepository = characterRepository;
        }

        /// <inheritdoc />
        public async Task<GetAllCharactersResult> ExecuteAsync()
        {
            var characters = await characterRepository.GetAllCharactersAsync();

            if (characters == null) return null;

            var result = new GetAllCharactersResult()
            {
                Characters = characters.ToList()
            };

            return result;
        }

        #region IDisposable Support

        /// < inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    characterRepository?.Dispose();
                }
                disposedValue = true;
            }
        }

        /// < inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}
