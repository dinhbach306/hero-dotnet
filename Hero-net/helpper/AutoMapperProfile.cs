using AutoMapper;
using Hero_net.DTO.Character;

namespace Hero_net.helpper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Character, GetCharacterDto>(); //Này phải theo thứ tự bên mapper.Map
        CreateMap<AddCharacterDto, Character>();
        CreateMap<UpdateCharacterDto, Character>();
    }
}