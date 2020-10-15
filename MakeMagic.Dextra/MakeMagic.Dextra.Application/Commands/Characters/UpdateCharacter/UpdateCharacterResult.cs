using MakeMagic.Dextra.Domain.Entities;

namespace MakeMagic.Dextra.Application.Commands.Characters.UpdateCharacter
{
    /// <summary>
    /// Result from <see cref="IUpdateCharacterUseCase"/>.
    /// </summary>
    public class UpdateCharacterResult
    {
        /// <summary>
        /// <see cref="Character"/>.
        /// </summary>
        public Character Character { get; set; }
    }
}
