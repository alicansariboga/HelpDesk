global using MediatR;
global using Microsoft.AspNetCore.Mvc;

global using HelpDesk.Application.Interfaces;
global using HelpDesk.Application.Services;
global using HelpDesk.Persistence.Context;
global using HelpDesk.Persistence.Repositories;

global using HelpDesk.Application.Features.Mediator.Commands.TicketCommands;
global using HelpDesk.Application.Features.Mediator.Queries.TicketQueries;

global using HelpDesk.Application.Features.Mediator.Commands.TicketDocumentCommands;
global using HelpDesk.Application.Features.Mediator.Queries.TicketDocumentQueries;

global using HelpDesk.Application.Features.Mediator.Commands.TicketStatusCommands;
global using HelpDesk.Application.Features.Mediator.Queries.TicketStatusQueries;

global using HelpDesk.Application.Features.Mediator.Commands.TicketRouteCommands;
global using HelpDesk.Application.Features.Mediator.Queries.TicketRouteQueries;

global using HelpDesk.Application.Features.Mediator.Commands.AppUserCommands;
global using HelpDesk.Application.Features.Mediator.Queries.AppUserQueries;

global using HelpDesk.Application.Features.Mediator.Queries.StaffDepartmentQueries;

global using HelpDesk.Application.Features.Mediator.Commands.MailCommands;
global using HelpDesk.Application.Features.Mediator.Queries.MailQueries;