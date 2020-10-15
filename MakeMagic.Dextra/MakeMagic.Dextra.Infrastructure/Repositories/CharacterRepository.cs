using MakeMagic.Dextra.Infrastructure.EntityFrameworkDataAccess;
using MakeMagic.Dextra.Infrastructure.EntityFrameworkDataAccess.Entities;
using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Infrastructure.Repositories
{
    /// <inheritdoc />
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IContext context;
        private bool disposedValue = false;

        public CharacterRepository(IContext context)
        {
            this.context = context;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Domain.Entities.Character>> GetAllCharactersAsync()
        {
            var entities = await context.Characters
                .Where(x => !x.MarkedForDeletion)
                .AsNoTracking()
                .ToListAsync();

            return Map(entities);
        }

        /// <inheritdoc />
        public async Task<Domain.Entities.Character> GetCharacterAsync(Guid id)
        {
            var entity =
                await context.Characters
                .FirstOrDefaultAsync(x => x.Id.Equals(id) && !x.MarkedForDeletion);

            return Map(entity);
        }

        /// <inheritdoc />
        public async Task<Domain.Entities.Character> DeleteCharacterAsync(Guid id)
        {
            var entity = await context.Characters
                .FirstOrDefaultAsync(x => x.Id.Equals(id) && !x.MarkedForDeletion);

            if (entity == null) return null;

            entity.Delete();

            var updatedEntity = context.Characters.Update(entity);

            if (updatedEntity != null)
            {
                await context.SaveChangesAsync();
                return Map(entity);
            }

            return null;
        }

        /// <inheritdoc />
        public async Task<Domain.Entities.Character> AddCharacterAsync(Domain.Entities.Character character)
        {
            var entity = Map(character);

            await context.Characters.AddAsync(entity);

            await context.SaveChangesAsync();

            return Map(entity);
        }

        /// <inheritdoc />
        public async Task<Domain.Entities.Character> UpdateCharacterAsync(Guid id, string role, string school)
        {
            var entity = await context.Characters
                .FirstOrDefaultAsync(x => x.Id.Equals(id) && !x.MarkedForDeletion);

            if (entity == null) return null;

            entity.Update(role, school);

            var updatedEntity = context.Characters.Update(entity);

            if (updatedEntity != null)
            {
                await context.SaveChangesAsync();
                return Map(entity);
            }
                
            return null;
        }

        private Domain.Entities.Character Map(Character character)
        {
            if (character == null) return null;

            return Domain.Entities.Character.Load(
                    character.Id,
                    character.Name,
                    character.Role,
                    character.School,
                    character.HouseId,
                    character.HouseName,
                    character.Patronus,
                    character.CreatedAt,
                    character.UpdatedAt
                );
        }

        private List<Domain.Entities.Character> Map(List<Character> entities)
        {
            if (entities == null) return null;

            var characters = new List<Domain.Entities.Character>();

            foreach(var entity in entities)
            {
                characters.Add(Map(entity));
            };

            return characters;
        }

        private Character Map(Domain.Entities.Character character)
        {
            if (character == null) return null;

            return new Character()
            {
                Id = character.Id,
                Name = character.Name,
                Role = character.Role,
                School = character.School,
                HouseId = character.HouseId,
                HouseName = character.HouseName,
                Patronus = character.Patronus,
                CreatedAt = character.CreatedAt,
                UpdatedAt = character.UpdatedAt
            };
        }

        #region IDisposable Support

        /// < inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context?.Dispose();
                }
                disposedValue = true;
            }
        }

        /// < inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}
