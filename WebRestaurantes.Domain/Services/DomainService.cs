
namespace WebRestaurantes.Domain
{
    public class DomainService : BaseService<Domain, IDomainRepository>, IDomainService 
    {
        public DomainService(IDomainRepository domainRepository) : base(domainRepository)
        {
        }
    }
}
