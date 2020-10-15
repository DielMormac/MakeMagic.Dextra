using MakeMagic.Dextra.Api.V1.Controllers;
using MakeMagic.Dextra.Application.Commands.Characters.AddCharacter;
using MakeMagic.Dextra.Application.Commands.Characters.DeleteCharacter;
using MakeMagic.Dextra.Application.Commands.Characters.GetAllCharacters;
using MakeMagic.Dextra.Application.Commands.Characters.GetCharacter;
using MakeMagic.Dextra.Application.Commands.Characters.UpdateCharacter;
using Domains = MakeMagic.Dextra.Domain.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;
using MakeMagic.Dextra.Api.V1.Models.Characters.AddCharacter;
using MakeMagic.Dextra.Api.V1.Models.Characters.UpdateCharacter;

namespace MakeMagic.Dextra.Tests.Api.Controllers
{
    public class CharacterControllerTests
    {
        private readonly IGetCharacterUseCase getCharacterUseCase;
        private readonly IGetAllCharactersUseCase getAllCharactersUseCase;
        private readonly IAddCharacterUseCase addCharacterUseCase;
        private readonly IDeleteCharacterUseCase deleteCharacterUseCase;
        private readonly IUpdateCharacterUseCase updateCharacterUseCase;
        private readonly CharacterController characterController;
        private readonly Guid id1 = Guid.NewGuid();
        private readonly string name1 = "character_name1";
        private readonly string role1 = "character_role1";
        private readonly string school1 = "character_school1";
        private readonly string houseId1 = "character_houseId1";
        private readonly string houseName1 = "character_houseName1";
        private readonly string patronus1 = "character_patronus1";
        private readonly DateTime createdAt1 = DateTime.UtcNow;
        private readonly DateTime updatedAt1 = DateTime.UtcNow;
        private readonly Guid id2 = Guid.NewGuid();
        private readonly string name2 = "character_name2";
        private readonly string role2 = "character_role2";
        private readonly string school2 = "character_school2";
        private readonly string houseId2 = "character_houseId2";
        private readonly string houseName2 = "character_houseName2";
        private readonly string patronus2 = "character_patronus2";
        private readonly DateTime createdAt2 = DateTime.UtcNow;
        private readonly DateTime updatedAt2 = DateTime.UtcNow;
        private List<Domains.Character> domainList;

        public CharacterControllerTests()
        {
            getCharacterUseCase = Substitute.For<IGetCharacterUseCase>();
            getAllCharactersUseCase = Substitute.For<IGetAllCharactersUseCase>();
            addCharacterUseCase = Substitute.For<IAddCharacterUseCase>();
            deleteCharacterUseCase = Substitute.For<IDeleteCharacterUseCase>();
            updateCharacterUseCase = Substitute.For<IUpdateCharacterUseCase>();
            characterController = new CharacterController();
            domainList = new List<Domains.Character>();
        }

        [Fact]
        public void WhenGetting_ReturnSuccess()
        {
            var character = Domains.Character.Load(
                    id1,
                    name1,
                    role1,
                    school1,
                    houseId1,
                    houseName1,
                    patronus1,
                    createdAt1,
                    updatedAt1
                );

            var result = new GetCharacterResult()
            {
                Character = character
            };

            getCharacterUseCase.ExecuteAsync(id1).Returns(result);

            var response = characterController.GetCharacter(id1, getCharacterUseCase);

            Assert.NotNull(response);
        }

        [Fact]
        public void WhenGettingAll_ReturnSuccess()
        {
            var character1 = Domains.Character.Load(
                    id1,
                    name1,
                    role1,
                    school1,
                    houseId1,
                    houseName1,
                    patronus1,
                    createdAt1,
                    updatedAt1
                );

            var character2 = Domains.Character.Load(
                    id2,
                    name2,
                    role2,
                    school2,
                    houseId2,
                    houseName2,
                    patronus2,
                    createdAt2,
                    updatedAt2
                );

            domainList.Add(character1);
            domainList.Add(character2);

            var result = new GetAllCharactersResult()
            {
                Characters = domainList
            };

            getAllCharactersUseCase.ExecuteAsync().Returns(result);

            var response = characterController.GetAllCharacters(getAllCharactersUseCase);

            Assert.NotNull(response);
        }

        [Fact]
        public void WhenAdding_ReturnSuccess()
        {
            var character = Domains.Character.Load(
                    id1,
                    name1,
                    role1,
                    school1,
                    houseId1,
                    houseName1,
                    patronus1,
                    createdAt1,
                    updatedAt1
                );

            var result = new AddCharacterResult()
            {
                Character = character
            };

            var request = new AddCharacterRequest()
            {
                Name = name1,
                Role = role1,
                School = school1,
                HouseId = houseId1,
                Patronus = patronus1
            };

            addCharacterUseCase.ExecuteAsync(character).Returns(result);

            var response = characterController.AddCharacter(request, addCharacterUseCase);

            Assert.NotNull(response);
        }

        [Fact]
        public void WhenUpdating_ReturnSuccess()
        {
            var character = Domains.Character.Load(
                    id1,
                    name1,
                    role1,
                    school1,
                    houseId1,
                    houseName1,
                    patronus1,
                    createdAt1,
                    updatedAt1
                );

            var result = new UpdateCharacterResult()
            {
                Character = character
            };


            var request = new UpdateCharacterRequest()
            {
                Role = role1,
                School = school1
            };

            updateCharacterUseCase.ExecuteAsync(id1, role1, school1).Returns(result);

            var response = characterController.UpdateCharacter(id1, request, updateCharacterUseCase);

            Assert.NotNull(response);
        }

        [Fact]
        public void WhenDeleting_ReturnSuccess()
        {
            var character = Domains.Character.Load(
                    id1,
                    name1,
                    role1,
                    school1,
                    houseId1,
                    houseName1,
                    patronus1,
                    createdAt1,
                    updatedAt1
                );

            var result = new DeleteCharacterResult()
            {
                Character = character
            };

            deleteCharacterUseCase.ExecuteAsync(id1).Returns(result);

            var response = characterController.DeleteCharacter(id1, deleteCharacterUseCase);

            Assert.NotNull(response);
        }
    }
}
