namespace CommonInterfaces
{
    public class Car
    {
        public string VinNumber { get; set; }

        public string RegNumber { get; set; }

        public Status CarStatus { get; set; }

        public string StatusString => CarStatus.ToString();

        public int CompanyCarId { get; set; }

        public enum Status { Available, NotAvailable, Broken }
    }

    
}