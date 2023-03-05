using Hero_net.DTO.Character;
using Hero_net.Service;
using Microsoft.AspNetCore.Mvc;
namespace Hero_net.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService; //Dependency Injection
    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _characterService.GetAllCharacters();
        if (response.Data != null && response.Data.Any())
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        return NotFound();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _characterService.GetCharacterById(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
    {
        return Ok(await _characterService.AddCharacter(newCharacter));
    }
    
    [HttpPut]
    public async Task<IActionResult>  UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        var response = await _characterService.UpdateCharacter(updatedCharacter);
        if (response.Data == null)
            return NotFound(response);
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult>  DeleteCharacter(int id)
    {
        var response = await _characterService.DeleteCharacter(id);
        if (response.Data == null)
            return NotFound(response);
        return Ok(response);
    }
}