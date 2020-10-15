using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Provides interaction with the characters repository in database context.
    /// </summary>
    public interface ICharacterRepository : IDisposable
    {
        /// <summary>
        /// Get all characters.
        /// </summary>
        /// <returns><see cref="IEnumerable{Domain.Entities.Character}"/>.</returns>
        Task<IEnumerable<Domain.Entities.Character>> GetAllCharactersAsync();

        /// <summary>
        /// Get a specific character.
        /// </summary>
        /// <param name="id"><see cref="Guid"/>.</param>
        /// <returns><see cref="Task{Domain.Entities.Character}"/></returns>
        Task<Domain.Entities.Character> GetCharacterAsync(Guid id);

        /// <summary>
        /// Delete an specific character.
        /// </summary>
        /// <param name="id"><see cref="Guid"/>.</param>
        /// <returns><see cref="Task{Domain.Entities.Character}"/></returns>
        Task<Domain.Entities.Character> DeleteCharacterAsync(Guid id);

        /// <summary>
        /// Adds a new character.
        /// </summary>
        /// <param name="character"><see cref="Domain.Entities.Character"/>.</param>
        /// <returns><see cref="Task{Domain.Entities.Character}"/></returns>
        Task<Domain.Entities.Character> AddCharacterAsync(Domain.Entities.Character character);

        /// <summary>
        /// Update a specific character.
        /// </summary>
        /// <param name="id"><see cref="Guid"/>.</param>
        /// <param name="role">string.</param>
        /// <param name="school">string.</param>
        /// <returns><see cref="Task{Domain.Entities.Character}"/></returns>
        Task<Domain.Entities.Character> UpdateCharacterAsync(Guid id, string role, string school);
    }
}
