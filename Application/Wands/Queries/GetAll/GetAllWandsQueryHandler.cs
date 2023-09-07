﻿using Application.Common.CQRS;
using Application.Common.Interfaces.Persistence;
using Domain.Models;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wands.Queries.GetAll
{
    internal class GetAllWandsQueryHandler : IQueryHandler<GetAllWandsQuery, ICollection<Wand>>
    {
        private readonly IWandRepository _wandRepository;

        public GetAllWandsQueryHandler(IWandRepository wandRepository)
        {
            _wandRepository = wandRepository;
        }

        public async Task<ErrorOr<ICollection<Wand>>> Handle(GetAllWandsQuery query, CancellationToken cancellationToken)
        {
            var allWands = await _wandRepository.GetAllWandsAsync();

            return ErrorOrFactory.From(allWands);
        }
    }
}