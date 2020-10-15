using MakeMagic.Dextra.Domain.Entities;

namespace MakeMagic.Dextra.Application.Commands.Characters.DeleteCharacter
{
    /// <summary>
    /// Result from <see cref="IDeleteCharacterUseCase"/>.
    /// </summary>
    public class DeleteCharacterResult
    {
        /// <summary>
        /// <see cref="Character"/>.
        /// </summary>
        public Character Character { get; set; }
    }
}
