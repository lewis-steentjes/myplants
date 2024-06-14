using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace PostgrestExample.models
{
    [Table("plants")]
    class Plant : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("owner_id")]
        public int OwnerId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("plant_name")]
        public string Name { get; set; } = null!;

        [Column("plant_description")]
        public string Desc { get; set; } = null!;

        [Column("watering_frequency")]
        public int WateringFrequency { get; set; }

        public override string ToString()
        {
            return $"ID:\t{Id},\nOwner:\t{OwnerId},\nName:\t{Name},";
        }
    }
}
