using AutoMapper;
using bilerplate.Application.Features.Categories.Commands.CreateCategory;
using bilerplate.Application.Features.Categories.Commands.StoredProcedure;
using bilerplate.Application.Features.Categories.Queries.GetCategoriesList;
using bilerplate.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using bilerplate.Application.Features.Events.Commands.CreateEvent;
using bilerplate.Application.Features.Events.Commands.Transaction;
using bilerplate.Application.Features.Events.Commands.UpdateEvent;
using bilerplate.Application.Features.Events.Queries.GetEventDetail;
using bilerplate.Application.Features.Events.Queries.GetEventsExport;
using bilerplate.Application.Features.Events.Queries.GetEventsList;
using bilerplate.Application.Features.Orders.GetOrdersForMonth;
using bilerplate.Domain.Entities;

namespace bilerplate.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {          
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, TransactionCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, StoredProcedureCommand>();
            CreateMap<Category, StoredProcedureDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();
        }
    }
}
