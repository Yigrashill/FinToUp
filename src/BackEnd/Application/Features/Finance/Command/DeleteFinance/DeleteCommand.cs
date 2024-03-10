using AutoMapper;
using MediatR;

namespace Application.Features.Finance.Command.DeleteFinance;
public class DeleteCommand : IRequest<Unit>
{
    public int Id { get; set; }
}