using System.ComponentModel.DataAnnotations;

namespace MakeMagic.Dextra.Api.V1.Models.Characters.AddCharacter
{
    public class AddCharacterRequest
    {
        /// <summary>
        /// Name of the character.
        /// </summary>
        [Required(ErrorMessage = "Please inform character name.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character name must contain 3-100 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Role/Profession of the character.
        /// </summary>
        [Required(ErrorMessage = "Please inform character role.")]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "Character role must contain 3-35 characters.")]
        public string Role { get; set; }

        /// <summary>
        /// School of the character.
        /// </summary>
        [Required(ErrorMessage = "Please inform character school.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character school must contain 3-100 characters.")]
        public string School { get; set; }

        /// <summary>
        /// Id of the character's house (from Potter API).
        /// </summary>
        [Required(ErrorMessage = "Please inform house Id.")]
        [StringLength(24, MinimumLength = 24, ErrorMessage = "House id must contain 24 characters.")]
        public string HouseId { get; set; }

        /// <summary>
        /// Animal from Patronus spell of the character.
        /// </summary>
        [Required(ErrorMessage = "Please inform character patronus.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Character patronus must contain 3-35 characters.")]
        public string Patronus { get; set; }
    }
}
