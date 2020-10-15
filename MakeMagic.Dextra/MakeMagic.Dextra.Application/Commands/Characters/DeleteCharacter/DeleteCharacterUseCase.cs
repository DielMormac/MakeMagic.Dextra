using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Application.Commands.Characters.DeleteCharacter
{
    /// <inheritdoc />
    public class DeleteCharacterUseCase : IDeleteCharacterUseCase
    {
        private readonly ICharacterRepository characterRepository;
        private bool disposedValue = false;

        public DeleteCharacterUseCase(
                ICharacterRepository characterRepository
            )
        {
            this.characterRepository = characterRepository;
        }

        /// <inheritdoc />
        public async Task<DeleteCharacterResult> ExecuteAsync(Guid id)
        {
            var character = await characterRepository.DeleteCharacterAsync(id);

            if (character == null) return null;

            var result = new DeleteCharacterResult()
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
