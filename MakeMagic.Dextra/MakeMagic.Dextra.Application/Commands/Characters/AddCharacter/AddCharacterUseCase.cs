using MakeMagic.Dextra.Domain.Entities;
using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Application.Commands.Characters.AddCharacter
{
    /// <inheritdoc />
    public class AddCharacterUseCase : IAddCharacterUseCase
    {
        private readonly ICharacterRepository characterRepository;
        private readonly IPotterApiRepository potterApiRepository;
        private bool disposedValue = false;

        /// <inheritdoc />
        public AddCharacterUseCase(
                ICharacterRepository characterRepository,
                IPotterApiRepository potterApiRepository
            )
        {
            this.characterRepository = characterRepository;
            this.potterApiRepository = potterApiRepository;
        }

        /// <inheritdoc />
        public async Task<AddCharacterResult> ExecuteAsync(Character character)
        {
            try
            {
                var house = await potterApiRepository.GetByHouseId(character.HouseId);
                
                character = Character.Load(
                        character.Id,
                        character.Name,
                        character.Role,
                        character.School,
                        house.ToList().FirstOrDefault()._id,
                        house.ToList().FirstOrDefault().Name,
                        character.Patronus,
                        character.CreatedAt,
                        character.UpdatedAt
                    );

                character = await characterRepository.AddCharacterAsync(character);

                var result = new AddCharacterResult()
                {
                    Character = character
                };

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
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
                    potterApiRepository?.Dispose();
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
