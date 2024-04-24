using MediatR;
using TODO.UseCases.Models;

namespace TODO.UseCases.Items.MarkAsDone;

public class MarkAsDoneCommand(int id) : IRequest<ServiceResult>
{
    public int Id { get; } = id;
}