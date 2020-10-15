using System;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Application.Commands.Characters.DeleteCharacter
{
    public interface IDeleteCharacterUseCase : IDisposable
    {
        /// <summary>
        /// Execute the current use case.
        /// </summary>
        /// <param name="id"><see cref="Guid"/>.</param>
        /// <returns><see cref="Task{DeleteCharacterResult}"/>.</returns>
        Task<DeleteCharacterResult> ExecuteAsync(Guid id);
    }
}
