namespace APIService.Domain.Entities
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Backpack Backpack { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
    }
}
