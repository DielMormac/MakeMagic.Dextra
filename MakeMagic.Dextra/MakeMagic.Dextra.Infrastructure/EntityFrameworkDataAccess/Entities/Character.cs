using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeMagic.Dextra.Infrastructure.EntityFrameworkDataAccess.Entities
{
    /// <summary>
    /// Represents a character in database context.
    /// </summary>
    public class Character : BaseEntity
    {
        /// <summary>
        /// Name of the character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Role of the character.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// School of the character.
        /// </summary>
        public string School { get; set; }

        /// <summary>
        /// Id of the characters house (collected from Potter Api).
        /// </summary>
        public string HouseId { get; set; }

        /// <summary>
        /// Name of the characters house (collected from Potter Api).
        /// </summary>
        public string HouseName { get; set; }

        /// <summary>
        /// Patronus of the character.
        /// </summary>
        public string Patronus { get; set; }

        /// <summary>
        /// Update role and school of the character.
        /// </summary>
        /// <param name="role">string.</param>
        /// <param name="school">string.</param>
        public void Update(string role, string school)
        {
            Role = role;
            School = school;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
