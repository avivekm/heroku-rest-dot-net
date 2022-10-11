using bilerplate.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace bilerplate.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<Response<IEnumerable<CategoryListVm>>>
    {
    }
}
