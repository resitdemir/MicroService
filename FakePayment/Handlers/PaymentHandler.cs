using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakePayment.Handlers
{
    public class PaymentHandler
    {
        public RequestDelegate Handler()
        {
            return async c =>
            {
                await c.Response.WriteAsync("hello");
            };
        }
    }
}
