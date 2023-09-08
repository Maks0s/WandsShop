﻿

namespace Presentation.Common.DTO.Response
{
    public class WandResponse
    {
        public string Name { get => $"{Wood} wand"; }

        public string Core { get; set; } = "";

        public string Wood { get; set; } = "";

        public decimal LengthInInches { get; set; }

        public string? Owner { get; set; }

        public string Description { get; set; } = "";
    }
}