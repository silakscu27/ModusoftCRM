﻿namespace ModusoftCRM.Application.Features.FranchiseTypes.Queries.GetAll
{
    public class FranchiseTypeGetAllDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
    }
}
