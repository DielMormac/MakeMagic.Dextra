using System;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Application.Commands.Characters.GetCharacter
{
    public interface IGetCharacterUseCase : IDisposable
    {
        /// <summary>
        /// Execute the current use case.
        /// </summary>
        /// <param name="id"><see cref="Guid"/>.</param>
        /// <returns><see cref="Task{GetCharacterResult}"/>.</returns>
        Task<GetCharacterResult> ExecuteAsync(Guid id);
    }
}
