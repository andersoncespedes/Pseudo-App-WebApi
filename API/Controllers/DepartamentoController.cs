
using System.Collections.Generic;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers;

public class DepartamentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork ;
    public DepartamentoController(IUnitOfWork unitOfWork){
        _unitOfWork = unitOfWork;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Departamento>>> Get(){
        var datos = await _unitOfWork.Departamentos.GetAll();
        return Ok(datos);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Departamento>> Get(int id){
        var datos = await _unitOfWork.Departamentos.GetById(id);
        return Ok(datos);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Departamento>> Post([FromBody] Departamento departamento){
        _unitOfWork.Departamentos.Add(departamento);
        if(departamento == null){
            return BadRequest();
        }
        await _unitOfWork.Save();
        return CreatedAtAction(nameof(Post), new {id = departamento.Id}, departamento);
    }

}
