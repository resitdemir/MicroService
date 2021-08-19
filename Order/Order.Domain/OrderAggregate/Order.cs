﻿using Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedTime { get; private set; }
        public Address Address { get; private set; }
        public string BuyerId { get; private set; }
        //backing field , encapsule etmeyi arttırır
        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public Order()
        {
        }
        public Order(string buyerId , Address address)
        {
            _orderItems = new List<OrderItem>();
            CreatedTime = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
        }

        public void AddOrderItem(string productId, string productName, string pictureUrl, decimal price)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);

            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, pictureUrl, price);
                _orderItems.Add(newOrderItem);
            }
        }

        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }
}
