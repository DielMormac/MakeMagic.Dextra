using System.ComponentModel.DataAnnotations;

namespace MakeMagic.Dextra.Api.V1.Models.Characters.UpdateCharacter
{
    public class UpdateCharacterRequest
    {
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
    }
}
