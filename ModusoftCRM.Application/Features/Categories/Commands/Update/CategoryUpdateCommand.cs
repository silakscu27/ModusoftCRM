﻿using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Categories.Commands.Update
{
    public class CategoryUpdateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}