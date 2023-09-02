
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.Dtos;
namespace API.Controllers;

public class DepartamentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork ;
    private readonly IMapper _mapper;
    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get(){
        var datos = await _unitOfWork.Departamentos.GetAll();
        return _mapper.Map<List<DepartamentoDto>>(datos);
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
    public async Task<ActionResult<DepartamentoDto>> Post([FromBody] DepartamentoDto departamento){
        var datos =  _mapper.Map<Departamento>(departamento);
        _unitOfWork.Departamentos.Add(datos);
        if(departamento == null){
            return BadRequest();
        }
        await _unitOfWork.Save();
        return CreatedAtAction(nameof(Post), new {id = datos.Id}, departamento);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Departamento>> Delete(int id){
        var dato = await _unitOfWork.Departamentos.GetById(id);
        if(dato == null){
            return NotFound();
        }
        _unitOfWork.Departamentos.Remove(dato);
        await _unitOfWork.Save();
        return NoContent();
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Departamento>> Put(int id,[FromBody] DepartamentoDto departamento){
        var depNuevo = _mapper.Map<Departamento>(departamento);
        var depAnterior = await _unitOfWork.Departamentos.GetById(id);
        if(depNuevo == null){
            return BadRequest();
        }
        _unitOfWork.Departamentos.Update(depNuevo, depAnterior);
        await _unitOfWork.Save();
        return depNuevo;
    }
}
