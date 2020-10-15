using System;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Application.Commands.Characters.UpdateCharacter
{
    public interface IUpdateCharacterUseCase : IDisposable
    {
        /// <summary>
        /// Execute the current use case.
        /// </summary>
        /// <param name="id"><see cref="Guid"/>.</param>
        /// <param name="role">string.</param>
        /// <param name="school">string.</param>
        /// <returns><see cref="Task{GetCharacterResult}"/>.</returns>
        Task<UpdateCharacterResult> ExecuteAsync(Guid id, string role, string school);
    }
}
