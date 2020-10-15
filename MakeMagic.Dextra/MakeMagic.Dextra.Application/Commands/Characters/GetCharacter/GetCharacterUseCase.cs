using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Application.Commands.Characters.GetCharacter
{
    public class GetCharacterUseCase : IGetCharacterUseCase
    {
        private readonly ICharacterRepository characterRepository;
        private bool disposedValue = false;

        /// <inheritdoc />
        public GetCharacterUseCase(
                ICharacterRepository characterRepository
            )
        {
            this.characterRepository = characterRepository;
        }

        /// <inheritdoc />
        public async Task<GetCharacterResult> ExecuteAsync(Guid id)
        {
            var character = await characterRepository.GetCharacterAsync(id);

            if (character == null) return null;

            var result = new GetCharacterResult()
            {
                Character = character
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
