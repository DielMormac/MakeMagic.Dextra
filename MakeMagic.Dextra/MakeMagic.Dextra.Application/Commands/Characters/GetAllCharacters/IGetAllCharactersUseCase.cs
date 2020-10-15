using System;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Application.Commands.Characters.GetAllCharacters
{
    public interface IGetAllCharactersUseCase : IDisposable
    {
        /// <summary>
        /// Execute the current use case.
        /// </summary>
        /// <returns><see cref="Task{GetAllCharactersResult}"/>.</returns>
        Task<GetAllCharactersResult> ExecuteAsync();
    }
}
