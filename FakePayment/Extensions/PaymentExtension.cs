using FakePayment.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakePayment.Extensions
{
    public static class PaymentExtension
    {
        public static IApplicationBuilder Payment(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<PaymentMiddleware>();
        }
    }
}
