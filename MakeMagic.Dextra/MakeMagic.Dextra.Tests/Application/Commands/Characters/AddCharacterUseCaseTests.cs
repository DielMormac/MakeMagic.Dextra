using MakeMagic.Dextra.Application.Commands.Characters.AddCharacter;
using MakeMagic.Dextra.Domain.Entities;
using MakeMagic.Dextra.Infrastructure.Entities.PotterApi.Models;
using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MakeMagic.Dextra.Tests.Application.Commands.Characters
{
    public class AddCharacterUseCaseTests
    {
        private readonly ICharacterRepository characterRepository;
        private readonly IPotterApiRepository potterApiRepository;
        private readonly IAddCharacterUseCase addCharacterUseCase;
        private readonly Guid id = Guid.NewGuid();
        private readonly string name = "character_name";
        private readonly string role = "character_role";
        private readonly string school = "character_school";
        private readonly string houseId = "character_houseId";
        private readonly string houseName = "character_houseName";
        private readonly string patronus = "character_patronus";
        private readonly DateTime createdAt = DateTime.UtcNow;
        private readonly DateTime updatedAt = DateTime.UtcNow;
        private List<House> houses;

        public AddCharacterUseCaseTests()
        {
            characterRepository = Substitute.For<ICharacterRepository>();
            potterApiRepository = Substitute.For<IPotterApiRepository>();
            addCharacterUseCase = new AddCharacterUseCase(characterRepository, potterApiRepository);
            houses = new List<House>();
        }

        [Fact]
        public void WhenAddinAValidCharacter_ReturnTheCharacter()
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

            houses.Add(new House()
                {
                    _id = houseId,
                    Name = houseName
                }
            );

            potterApiRepository.GetByHouseId(houseId).ReturnsForAnyArgs(houses);
            characterRepository.AddCharacterAsync(validCharacter).ReturnsForAnyArgs(validCharacter);

            var result = addCharacterUseCase.ExecuteAsync(validCharacter).Result;

            Assert.Equal(houses.First()._id, result.Character.HouseId);
            Assert.Equal(houses.First().Name, result.Character.HouseName);
            Assert.Equal(validCharacter.Id, result.Character.Id);
        }
    }
}
