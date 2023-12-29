namespace APIService.Domain.Entities
{
    public class Weapon
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
