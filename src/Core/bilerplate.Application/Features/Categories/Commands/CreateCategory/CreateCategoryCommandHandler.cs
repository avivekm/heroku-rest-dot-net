﻿using AutoMapper;
using bilerplate.Application.Contracts.Persistence;
using bilerplate.Application.Responses;
using bilerplate.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using bilerplate.Application.Exceptions;

namespace bilerplate.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Response<CreateCategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMessageRepository _messageRepository;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<CreateCategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Response<CreateCategoryDto> createCategoryCommandResponse = null;

            var validator = new CreateCategoryCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var category = new Category() { Name = request.Name };
                category = await _categoryRepository.AddAsync(category);
                createCategoryCommandResponse = new Response<CreateCategoryDto>(_mapper.Map<CreateCategoryDto>(category), "success");
            }

            return createCategoryCommandResponse;
        }
    }
}
