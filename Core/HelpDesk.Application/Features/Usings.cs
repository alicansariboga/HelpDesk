global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;

global using MediatR;

global using HelpDesk.Domain.Entities;
global using HelpDesk.Application.Interfaces;
global using HelpDesk.Application.Interfaces.AppUserInterfaces;

global using HelpDesk.Application.Features.Mediator.Results.TicketResults;
global using HelpDesk.Application.Features.Mediator.Queries.TicketQueries;
global using HelpDesk.Application.Features.Mediator.Commands.TicketCommands;

global using HelpDesk.Application.Features.Mediator.Results.TicketDocumentResults;
global using HelpDesk.Application.Features.Mediator.Queries.TicketDocumentQueries;
global using HelpDesk.Application.Features.Mediator.Commands.TicketDocumentCommands;

global using HelpDesk.Application.Features.Mediator.Results.TicketRouteResults;
global using HelpDesk.Application.Features.Mediator.Queries.TicketRouteQueries;
global using HelpDesk.Application.Features.Mediator.Commands.TicketRouteCommands;

global using HelpDesk.Application.Features.Mediator.Results.TicketStatusResults;
global using HelpDesk.Application.Features.Mediator.Queries.TicketStatusQueries;
global using HelpDesk.Application.Features.Mediator.Commands.TicketStatusCommands;

global using HelpDesk.Application.Features.Mediator.Results.AppUserResults;
global using HelpDesk.Application.Features.Mediator.Queries.AppUserQueries;
global using HelpDesk.Application.Features.Mediator.Commands.AppUserCommands;

global using HelpDesk.Application.Features.Mediator.Results.MailResults;
global using HelpDesk.Application.Features.Mediator.Queries.MailQueries;
global using HelpDesk.Application.Features.Mediator.Commands.MailCommands;