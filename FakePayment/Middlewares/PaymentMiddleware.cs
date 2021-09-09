using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakePayment.Middlewares
{
    public class PaymentMiddleware
    {
        private RequestDelegate _next;

        public PaymentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("Ödeme alınıyor ve işleniyor");
            await _next.Invoke(httpContext);
            Console.WriteLine("Ödeme alındı ve işlendi. İşlemler sona erdi");

        }
    }
}
