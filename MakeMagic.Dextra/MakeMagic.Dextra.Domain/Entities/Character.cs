using System;

namespace MakeMagic.Dextra.Domain.Entities
{
    /// <summary>
    /// Represents a character from Harry Potter movie.
    /// </summary>
    public class Character : IEntity
    {
        /// <inheritdoc />
        public Guid Id { get; private set; }

        /// <summary>
        /// Name of the character.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Role/Profession of the character.
        /// </summary>
        public string Role { get; private set; }

        /// <summary>
        /// School of the character.
        /// </summary>
        public string School { get; private set; }

        /// <summary>
        /// Id of the character's house (from Potter API).
        /// </summary>
        public string HouseId { get; private set; }

        /// <summary>
        /// Name of the character's house (from Potter API).
        /// </summary>
        public string HouseName { get; private set; }

        /// <summary>
        /// Animal from Patronus spell of the character.
        /// </summary>
        public string Patronus { get; private set; }

        /// <inheritdoc />
        public DateTime CreatedAt { get; private set; }

        /// <inheritdoc />
        public DateTime UpdatedAt { get; private set; }

        /// <summary>
        /// Instantiate a new entity from type <see cref="Character"/>.
        /// </summary>
        /// <param name="name">string.</param>
        /// <param name="role">string.</param>
        /// <param name="school">string.</param>
        /// <param name="houseId">string.</param>
        /// <param name="patronus">string.</param>
        public Character(string name, string role, string school, string houseId, string patronus)
        {
            Id = Guid.NewGuid();
            Name = name;
            Role = role;
            School = school;
            HouseId = houseId;
            Patronus = patronus;
            var timeNow = DateTime.UtcNow;
            CreatedAt = timeNow;
            UpdatedAt = timeNow;
        }

        /// <summary>
        /// Load an entity from type <see cref="Character"/>.
        /// </summary>
        /// <param name="id"><see cref="Guid"/>.</param>
        /// <param name="name">string.</param>
        /// <param name="role">string.</param>
        /// <param name="school">string.</param>
        /// <param name="houseId">string.</param>
        /// <param name="houseName">string.</param>
        /// <param name="patronus">string.</param>
        /// <param name="createdAt"><see cref="DateTime"/>.</param>
        /// <param name="updatedAt"><see cref="DateTime"/>.</param>
        public static Character Load(Guid id, string name, string role, string school, string houseId, string houseName, string patronus, DateTime createdAt, DateTime updatedAt)
        {
            return new Character(
                    id,
                    name,
                    role,
                    school,
                    houseId,
                    houseName,
                    patronus,
                    createdAt,
                    updatedAt
                );
        }

        private Character(Guid id, string name, string role, string school, string houseId, string houseName, string patronus, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Role = role;
            School = school;
            HouseId = houseId;
            HouseName = houseName;
            Patronus = patronus;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
