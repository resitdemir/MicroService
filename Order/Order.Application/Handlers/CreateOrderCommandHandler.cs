﻿using MediatR;
using Order.Application.Commands;
using Order.Application.Dtos;
using Order.Domain.OrderAggregate;
using Order.Infrastructure;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _context;

        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.AddressDto.Province, request.AddressDto.Districh, request.AddressDto.Street,
                request.AddressDto.ZipCode, request.AddressDto.Line);

            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);

            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.PictureUrl, x.Price);
            });

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, 200);
        }
    }
}