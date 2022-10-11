using MediatR;
using System;

namespace bilerplate.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand: IRequest
    {
        public string EventId { get; set; }
    }
}
