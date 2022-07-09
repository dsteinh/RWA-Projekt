namespace rwaLib.Models
{
    public class TagType
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public override string ToString() => $"{TypeName}";
    }
}