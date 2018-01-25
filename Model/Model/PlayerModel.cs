
using MicroOrm.Pocos.SqlGenerator.Attributes;

namespace Model.Model
{
    [StoredAs("Players")]
    public class PlayerModel
    {
        [KeyProperty(Identity = true)]
        public int Id { get; set; }

        [StoredAs("NamePlayer")]
        public string Name { get; set; }
    }
}
