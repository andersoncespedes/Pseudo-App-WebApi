using Aplication.Repository;
using Persistencia.Data;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Dominio.Interfaces;
using API.Dtos;
namespace API.Controllers;
[ApiVersion("1.0")]
public class PaisController : BaseApiController
{
    private readonly IUnitOfWork _IUnitOfWork;
    private readonly IMapper _mapper;
    public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _IUnitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PaisDto>>> Get(){
        var datos = await _IUnitOfWork.Paises.GetAll();
        return _mapper.Map<List<PaisDto>>(datos);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaisDto>> Get(int id){
        var datos = await _IUnitOfWork.Paises.GetById(id);
        return _mapper.Map<PaisDto>(datos);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post([FromBody] PaisDto pais){
        var dato = _mapper.Map<Pais>(pais);
        _IUnitOfWork.Paises.Add(dato);
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
