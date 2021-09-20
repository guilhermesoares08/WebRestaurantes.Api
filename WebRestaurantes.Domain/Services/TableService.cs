namespace WebRestaurantes.Domain
{
    public class TableService : BaseService<Table, ITableRepository>, ITableService
    {
        public TableService(ITableRepository tableRepository) : base(tableRepository)
        {
        }
    }
}
