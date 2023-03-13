namespace DragonBallWiki.Models
{
    public class AbilityModel
    {
        public string Name { get; set; } = "unbekannt";
        public string Description { get; set; } = "leer";


        public override string ToString () => $"{Name}: {Description}";
    }
}
