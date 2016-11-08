using System.Collections.Generic;
using System.Web.Http;
using CommonInterfaces;
using DataLibrary;

namespace CarStatus.Controllers
{
    public class MeController : ApiController
    {
        private readonly ICarStore dataStore;
        public MeController()
        {
            dataStore = new MockDataStore();
        }

        public IEnumerable<CompanyCar> GetCompanyCars()
        {
            return dataStore.GetCompanyCars();
        }

        public IEnumerable<CompanyCar> GetCompanyCars(int? companyCarId)
        {
            return dataStore.GetCompanyCars(companyCarId);
        }

        public IEnumerable<CompanyCar> GetCompanyCars(Car.Status? filterStatus)
        {
            return dataStore.GetCompanyCars(null, filterStatus);
        }

        public IEnumerable<CompanyCar> GetCompanyCars(int? companyCarId, Car.Status? filterStatus)
        {
            return dataStore.GetCompanyCars(companyCarId,  filterStatus);
        } 
        
        // GET api/Me
    }
}