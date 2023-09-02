using System.Collections;
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CiudadController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CiudadController(IUnitOfWork unitOfWork, IMapper mapper){
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CiudadDto>>> Get(){
        var dato = await _unitOfWork.Ciudades.GetAll();
        return _mapper.Map<List<CiudadDto>>(dato);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CiudadDto>> Post([FromBody] CiudadDto ciudad){
        var dato = _mapper.Map<Ciudad>(ciudad);
        _unitOfWork.Ciudades.Add(dato);
        await _unitOfWork.Save(); 
        if(dato == null){
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new CiudadDto {Id = dato.Id}, dato);
    }
}
