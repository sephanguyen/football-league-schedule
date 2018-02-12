using MicroOrm.Dapper.Repositories.Attributes.LogicalDelete;

namespace Repositories.Enum
{
    public enum StatusDelete
    {

        Active = 0,

        [Deleted]
        Deleted = 1
    }
}
