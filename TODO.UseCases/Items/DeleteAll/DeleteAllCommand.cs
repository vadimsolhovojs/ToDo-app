using MediatR;
using TODO.UseCases.Models;

namespace TODO.UseCases.Items.DeleteAll;

public class DeleteAllCommand() : IRequest<ServiceResult>
{
}