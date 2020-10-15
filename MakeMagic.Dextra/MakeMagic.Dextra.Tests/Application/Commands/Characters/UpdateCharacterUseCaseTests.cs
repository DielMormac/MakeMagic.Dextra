using MakeMagic.Dextra.Application.Commands.Characters.UpdateCharacter;
using MakeMagic.Dextra.Domain.Entities;
using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using NSubstitute;
using System;
using Xunit;

namespace MakeMagic.Dextra.Tests.Application.Commands.Characters
{
    public class UpdateCharacterUseCaseTests
    {

        private readonly ICharacterRepository characterRepository;
        private readonly IUpdateCharacterUseCase updateCharacterUseCase;
        private readonly Guid id = Guid.NewGuid();
        private readonly string name = "character_name";
        private readonly string role = "character_role";
        private readonly string school = "character_school";
        private readonly string houseId = "character_houseId";
        private readonly string houseName = "character_houseName";
        private readonly string patronus = "character_patronus";
        private readonly DateTime createdAt = DateTime.UtcNow;
        private readonly DateTime updatedAt = DateTime.UtcNow;

        public UpdateCharacterUseCaseTests()
        {
            characterRepository = Substitute.For<ICharacterRepository>();
            updateCharacterUseCase = new UpdateCharacterUseCase(characterRepository);
        }

        [Fact]
        public void WhenUpdatingAValidCharacter_ReturnUpdated()
        {
            var validCharacter = Character.Load(
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

            characterRepository.UpdateCharacterAsync(id, role, school).Returns(validCharacter);

            var result = updateCharacterUseCase.ExecuteAsync(id, role, school).Result;

            Assert.Equal(validCharacter.Id, result.Character.Id);
            Assert.Equal(validCharacter.Name, result.Character.Name);
            Assert.Equal(validCharacter.Role, result.Character.Role);
            Assert.Equal(validCharacter.School, result.Character.School);
        }
    }
}
