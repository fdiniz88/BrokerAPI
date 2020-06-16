﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Broker.Application;
using Broker.Application.Configuration.Commands;
using Broker.Domain.Extensions;
using Broker.Infrastructure.Database;

namespace Broker.Infrastructure.Processing
{
    public class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T> where T:ICommand
    {
        private readonly ICommandHandler<T> _decorated;

        private readonly IUnitOfWork _unitOfWork;

        private readonly OrdersContext _ordersContext;

        public UnitOfWorkCommandHandlerDecorator(
            ICommandHandler<T> decorated, 
            IUnitOfWork unitOfWork, 
            OrdersContext ordersContext)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _ordersContext = ordersContext;
        }

        public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            await this._decorated.Handle(command, cancellationToken);     

            await this._unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}