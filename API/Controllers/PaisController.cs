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
}
