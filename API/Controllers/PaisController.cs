using Aplication.Repository;
using Persistencia.Data;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Dominio.Interfaces;
namespace API.Controllers;

public class PaisController : BaseApiController
{
    private readonly IUnitOfWork _IUnitOfWork;
    public PaisController(IUnitOfWork unitOfWork)
    {
        _IUnitOfWork = unitOfWork;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Pais>>> Get(){
        var datos = await _IUnitOfWork.Paises.GetAll();
        return Ok(datos);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Get(int id){
        var datos = await _IUnitOfWork.Paises.GetById(id);
        return Ok(datos);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post([FromBody] Pais pais){
         _IUnitOfWork.Paises.Add(pais);
        await _IUnitOfWork.Save();
         if(pais == null){
            return BadRequest();
         }
        return CreatedAtAction(nameof(Post), new {id = pais.Id}, pais);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Delete(int id){
        var dato = await _IUnitOfWork.Paises.GetById(id);
        if(dato == null){
            return BadRequest();
        }
        _IUnitOfWork.Paises.Remove(dato);
        await _IUnitOfWork.Save();
        return NoContent();
    }
}
