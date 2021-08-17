using Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.OrderAggregate
{
    public class Address : ValueObject
    {
        public string Province { get; private set; }
        public string Districh { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public string Line { get; private set; } // value objenin durumunu koruyorum. 

        public Address(string province, string districh, string street, string zipCode, string line)
        {
            Province = province;
            Districh = districh;
            Street = street;
            ZipCode = zipCode;
            Line = line;
        } 

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Province;
            yield return Districh;
            yield return Street;
            yield return ZipCode;
            yield return Line;
        }//yield bir den fazla return yaptırır. :d
    }
}
