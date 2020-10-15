using System;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Application.Commands.Characters.AddCharacter
{
    /// <summary>
    /// Represents the use case for adding a new character.
    /// </summary>
    public interface IAddCharacterUseCase : IDisposable
    {
        /// <summary>
        /// Execute the current use case.
        /// </summary>
        /// <param name="character"><see cref="Domain.Entities.Character"/>.</param>
        /// <returns><see cref="Task{AddCharacterResult}"/>.</returns>
        Task<AddCharacterResult> ExecuteAsync(Domain.Entities.Character character);
    }
}
