using house_rentals.Bussines;
using house_rentals.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Controllers
{
    public class TenantController : IController<Tenant>
    {
        private ICRUD<Tenant> tenantBusiness = new TenantBusiness();

        public TenantController() { }

        public TenantController(ICRUD<Tenant> tenantBusiness)
        {
            this.tenantBusiness = tenantBusiness;
        }

        public void Add(Tenant newTenant)
        {
            Tenant tenant = tenantBusiness.Get(newTenant);
            if (tenant != null)
            {
                throw new ArgumentException("Tenant with this ID already exists.");
            }
            tenantBusiness.Add(newTenant);
        }

        public void Delete(Tenant findTenant)
        {
            Tenant tenant = tenantBusiness.Get(findTenant);
            if (tenant != null)
            {
                tenantBusiness.Delete(findTenant);
            }
            else
            {
                throw new ArgumentException("Tenant not found.");
            }
        }

        public Tenant Get(Tenant findTenant)
        {
            Tenant tenant = tenantBusiness.Get(findTenant);
            if (tenant != null)
            {
                return tenant;
            }
            else
            {
                throw new ArgumentException("Tenant not found.");
            }
        }

        public List<Tenant> ListAll()
        {
            var tenants = tenantBusiness.GetAll();
            if (tenants.Count > 0)
            {
                return tenants;
            }
            else
            {
                throw new ArgumentException("The tenants list is empty.");
            }
        }

        public void Update(Tenant findTenant)
        {
            Tenant tenant = tenantBusiness.Get(findTenant);
            if (tenant != null)
            {
                tenantBusiness.Update(findTenant);
            }
            else
            {
                throw new ArgumentException("Tenant not found.");
            }
        }
    }
}
