using MakeMagic.Dextra.Domain.Entities;

namespace MakeMagic.Dextra.Application.Commands.Characters.AddCharacter
{
    /// <summary>
    /// Result from <see cref="IAddCharacterUseCase"/>.
    /// </summary>
    public class AddCharacterResult
    {
        /// <summary>
        /// <see cref="Character"/>.
        /// </summary>
        public Character Character { get; set; }
    }
}
