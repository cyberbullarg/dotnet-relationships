using System.Text.Json.Serialization;

namespace APIService.Domain.Entities
{
    public class Backpack
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid CharacterId { get; set; }
        [JsonIgnore]
        public Character Character { get; set; }
    }
}
