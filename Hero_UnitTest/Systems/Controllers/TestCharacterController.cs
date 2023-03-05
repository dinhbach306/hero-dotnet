using FluentAssertions;
using Hero_net.Controllers;
using Hero_net.DTO.Character;
using Hero_net.Models;
using Hero_net.Service;
using Hero_UnitTest.Fixtures;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Hero_UnitTest.Systems.Controllers;

public class TestCharacterController
{

    //test Get on success return status code 200
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        // Arrange
        var mockCharacterService = new Mock<ICharacterService>();
        mockCharacterService.Setup(service => service
            .GetAllCharacters())
            .ReturnsAsync(CharacterFixture.GetCharacters);

        var sut = new CharacterController(mockCharacterService.Object);

        // Act
        var result = (OkObjectResult) await sut.GetAll();

        // Assert
        result.StatusCode.Should().Be(200);
    }
    
    [Fact]
    public async Task Get_OnSuccess_InvokesUserServiceExactlyOnce()
    {
        // Arrange
        var mockUsersService = new Mock<ICharacterService>();
        mockUsersService.Setup(service => service
                .GetAllCharacters())
            .ReturnsAsync(CharacterFixture.GetCharacters);
        
        var sut = new CharacterController(mockUsersService.Object);
        
        // Act
        var result = await sut.GetAll();

        // Assert
        mockUsersService.Verify(service => service
            .GetAllCharacters(), Times.Once);
    }
    
    [Fact]
    public async Task Get_OnSuccess_ReturnListOfUsers()
    {
        // Arrange
        var mockUsersService = new Mock<ICharacterService>();

        mockUsersService.Setup(service => service
                .GetAllCharacters())
            .ReturnsAsync(CharacterFixture.GetCharacters);
        
        var sut = new CharacterController(mockUsersService.Object);
        
        // Act
        var result = await sut.GetAll();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult) result;
        objectResult.Value.Should().BeOfType<ServiceResponse<List<GetCharacterDto>>>();
    }
    
    [Fact]
    public async Task Get_OnNoUsersFound_ReturnsStatusCode404()
    {
        // Arrange
        var mockUsersService = new Mock<ICharacterService>();
        mockUsersService.Setup(service => service
                .GetAllCharacters())
            .ReturnsAsync(new ServiceResponse<List<GetCharacterDto>>());
        
        var sut = new CharacterController(mockUsersService.Object);
        
        // Act
        var result = await sut.GetAll();

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult) result;
        objectResult.StatusCode.Should().Be(404);
    }
}