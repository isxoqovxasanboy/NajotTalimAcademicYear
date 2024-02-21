using CRUD.Api.Models;
using CRUD.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CrudController : Controller
{
    private readonly CrudService _crudService;
    public CrudController()
    {
        _crudService = new CrudService();
    }
    
    
    
    [HttpPost]
    public async Task<IActionResult> Add(BoardGame game)
    {
        await _crudService.Add(game);
        return Ok("Success");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, BoardGame game)
    {
        await _crudService.Update(id,game);
        return Ok("OK");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int adminId)
    {
        await _crudService.Delete(adminId);
        return Ok("Ok");
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var result =  await _crudService.Get(id);
        return Ok(result);
    }
    
    
    
    
}