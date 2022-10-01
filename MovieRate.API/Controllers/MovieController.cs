using System.Linq.Expressions;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using MovieRate.Core.Interfaces;
using MovieRate.Core.Models;

namespace MovieRate.API.Controllers;

public class MovieController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IXmlHandler<Movie> _xmlHandler;

    public MovieController(IUnitOfWork unitOfWork, IXmlHandler<Movie> xmlHandler)
    {
        _unitOfWork = unitOfWork;
        _xmlHandler = xmlHandler;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var movie = await _unitOfWork.MovieRepository.GetByIdAsync(id);
       
        if (movie is null)
        {
            return NotFound("Movie with this id not found");
        }

        var xml = _xmlHandler.GenerateXml(movie);
        // save xml
        _xmlHandler.SaveXmlToFile(xml,"movie.xml");
        
        return Ok(movie);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var includes = new Expression<Func<Movie, object>>[]
        {
            m => m.Genre
        };
        return Ok(await _unitOfWork.MovieRepository.GetAllAsync(includes));
    }
    
}