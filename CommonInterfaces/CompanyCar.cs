using System.Collections.Generic;

namespace CommonInterfaces
{
    public class CompanyCar
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public IEnumerable<Car> Cars { get; set; }
    }
}