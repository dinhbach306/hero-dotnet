using Hero_net.DTO.Character;
using Hero_net.Models;

namespace Hero_UnitTest.Fixtures;

public static class CharacterFixture
{
    public static ServiceResponse<List<GetCharacterDto>> GetCharacters() => new()
    {
        Data =  new List<GetCharacterDto> {
            new()
            {
                Id = 1,
                Name = "David",
                HitPoints = 100,
                Strength = 10,
                Defense = 10,
                Intelligence = 10,
                Class = RpgClass.Knight
            },
            new()
            {
                Id = 2,
                Name = "Magnus",
                HitPoints = 100,
                Strength = 10,
                Defense = 10,
                Intelligence = 10,
                Class = RpgClass.Mage
            }
        },
        Message = "Success",
        Success = true,
    };
}
