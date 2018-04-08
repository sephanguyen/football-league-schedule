namespace Models.ConfigPostParameter
{
    public class ConfigUpdateParameter
    {
        public int Id { get; set; }
        public int Name { get; set; }
       
        public int Value { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}