using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRate.API.Dtos;
using MovieRate.Core.Interfaces;
using MovieRate.Core.Models;

namespace MovieRate.API.Controllers;

public class GenreController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenreController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _unitOfWork.GenreRepository.GetByIdAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _unitOfWork.GenreRepository.GetAllAsync(null, g => g.Name));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] GenreDto genreDto)
    {
        var genre = _mapper.Map<Genre>(genreDto);
        await _unitOfWork.GenreRepository.AddAsync(genre);
        await _unitOfWork.CompleteAsync();
        return Ok(genre);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromForm] GenreDto genreDto)
    {
        var genre = await _unitOfWork.GenreRepository.GetByIdAsync(id);
        if (genre == null)
        {
            return NotFound($"Genre with id {id} not found!");
        }

        genre.Name = genreDto.Name;
        
        _unitOfWork.GenreRepository.Update(genre);
        await _unitOfWork.CompleteAsync();
        return Ok(genre);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var genre = await _unitOfWork.GenreRepository.GetByIdAsync(id);
        if (genre == null)
        {
            return NotFound($"Genre with id {id} not found!");
        }

        _unitOfWork.GenreRepository.Delete(genre);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }
}