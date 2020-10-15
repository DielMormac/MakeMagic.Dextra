using MakeMagic.Dextra.Domain.Entities;
using System.Collections.Generic;

namespace MakeMagic.Dextra.Application.Commands.Characters.GetAllCharacters
{
    /// <summary>
    /// Result from <see cref="IGetAllCharactersUseCase"/>.
    /// </summary>
    public class GetAllCharactersResult
    {
        /// <summary>
        /// <see cref="List{Character}"/>.
        /// </summary>
        public List<Character> Characters { get; set; }
    }
}
