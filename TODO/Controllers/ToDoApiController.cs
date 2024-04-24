using MediatR;
using Microsoft.AspNetCore.Mvc;
using TODO.Extensions;
using TODO.Models;
using TODO.UseCases.Items.AddItem;
using TODO.UseCases.Items.DeleteAll;
using TODO.UseCases.Items.DeleteItem;
using TODO.UseCases.Items.GetItems;
using TODO.UseCases.Items.MarkAsDone;

namespace TODO.Controllers;

[Route("api/todo")]
[ApiController]
public class ToDoApiController : ControllerBase
{
    private readonly IMediator _mediator;

    public ToDoApiController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> AddItem(AddItemRequest request)
    {
        return (await _mediator
            .Send(new AddItemCommand(request)))
            .ToActionResult();
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> MarkAsDone(int id)
    {
        return (await _mediator
            .Send(new MarkAsDoneCommand(id)))
            .ToActionResult();
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetItems()
    {
        return (await _mediator
            .Send(new GetItemsQuery()))
            .ToActionResult();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        return (await _mediator
            .Send(new DeleteItemCommand(id)))
            .ToActionResult();
    }

    [HttpDelete]
    [Route("clear")]
    public async Task<IActionResult> Clear()
    {
        return (await _mediator
            .Send(new DeleteAllCommand()))
            .ToActionResult();
    }
}