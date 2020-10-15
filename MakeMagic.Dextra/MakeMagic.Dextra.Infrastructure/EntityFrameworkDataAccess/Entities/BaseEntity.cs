using System;

namespace MakeMagic.Dextra.Infrastructure.EntityFrameworkDataAccess.Entities
{
    /// <summary>
    /// Abstraction base for database entities.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Id of the entity.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date of last update.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Represents if the entity is marked for deletion.
        /// </summary>
        public bool MarkedForDeletion { get; private set; } = false;

        /// <summary>
        /// Marks the current entity for deletion.
        /// </summary>
        public void Delete()
        {
            MarkedForDeletion = true;
        }
    }
}
