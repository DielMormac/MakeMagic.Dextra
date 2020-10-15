using MakeMagic.Dextra.Domain.Entities;

namespace MakeMagic.Dextra.Application.Commands.Characters.GetCharacter
{
    /// <summary>
    /// Result from <see cref="IGetCharacterUseCase"/>.
    /// </summary>
    public class GetCharacterResult
    {
        /// <summary>
        /// <see cref="Character"/>.
        /// </summary>
        public Character Character { get; set; }
    }
}
