using System;

namespace MakeMagic.Dextra.Api.V1.Models.Entities
{
    /// <summary>
    /// Represents a character in API context.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Character Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Role/Profession of the character.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// School of the character.
        /// </summary>
        public string School { get; set; }

        /// <summary>
        /// Id of the character's house (from Potter API).
        /// </summary>
        public string HouseId { get; set; }

        /// <summary>
        /// Name of the character's house (from Potter API).
        /// </summary>
        public string HouseName { get; set; }

        /// <summary>
        /// Animal from Patronus spell of the character.
        /// </summary>
        public string Patronus { get; set; }

        /// <summary>
        /// Date of the creation of the entity.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date of the last update in the entity.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
