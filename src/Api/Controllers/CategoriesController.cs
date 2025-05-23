﻿using Core.Domain.Entities;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync(CreateCategoryViewModel createCategoryViewModel,
        CancellationToken cancellationToken)
    {
        var id = await _service.CreateAsync(createCategoryViewModel, cancellationToken);

        return StatusCode(StatusCodes.Status201Created, id);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(UpdateCategoryViewModel updateCategoryViewModel,
        CancellationToken cancellationToken)
    {
        try
        {
            await _service.UpdateAsync(updateCategoryViewModel, cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var succeed = await _service.DeleteAsync(id, cancellationToken);
        if (succeed) return NoContent();
        return BadRequest("Não é possível excluir a categoria, pois existem produtos vinculados a ela.");
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Category>>> GetAsync(CancellationToken cancellationToken)
    {
        var categories = await _service.GetAsync(cancellationToken);
        return Ok(categories);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Category>> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _service.FindAsync(id, cancellationToken);
        if (category == null) return NotFound();
        return Ok(category);
    }
}