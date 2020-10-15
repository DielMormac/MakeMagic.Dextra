using System;
using System.Collections.Generic;
using System.Text;

namespace MakeMagic.Dextra.Domain.Entities
{
    /// <summary>
    /// Represents a generic entity in the context of domain.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Id of the Entity.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Date of the creation of the entity.
        /// </summary>
        DateTime CreatedAt { get; }

        /// <summary>
        /// Date of the last update in the entity.
        /// </summary>
        DateTime UpdatedAt { get; }
    }
}
