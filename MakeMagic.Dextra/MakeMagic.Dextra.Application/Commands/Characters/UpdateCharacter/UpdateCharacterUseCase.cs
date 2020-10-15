using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Application.Commands.Characters.UpdateCharacter
{
    /// <inheritdoc />
    public class UpdateCharacterUseCase : IUpdateCharacterUseCase
    {
        private readonly ICharacterRepository characterRepository;
        private bool disposedValue = false;

        public UpdateCharacterUseCase(
                ICharacterRepository characterRepository
            )
        {
            this.characterRepository = characterRepository;
        }

        /// <inheritdoc />
        public async Task<UpdateCharacterResult> ExecuteAsync(Guid id, string role, string school)
        {
            var character = await characterRepository.UpdateCharacterAsync(id, role, school);

            if (character == null) return null;

            var result = new UpdateCharacterResult()
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
