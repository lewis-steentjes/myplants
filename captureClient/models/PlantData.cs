using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace PostgrestExample.models
{
    [Table("plantsData")]
    class PlantData : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("plant_id")]
        public int PlantId { get; set; } = -1;

        [Column("recorded_at")]
        public DateTime RecordedAt { get; set; }

        [Column("image_frame")]
        public int ImageFrame { get; set; } = -1;

        [Column("video_location")]
        public string VideoFile { get; set; } = "";

        [Column("light")]
        public int LightLevel { get; set; }

        [Column("hydration")]
        public int HydrationLevel { get; set; }

        [Column("temperature")]
        public int TemperatureReading { get; set; }

        [Column("humidity")]
        public int HumidityReading { get; set; }

        public override string ToString()
        {
            return $"ID:\t\t{Id},\nPlantId:\t{PlantId},\nRecorded:\t{RecordedAt}\nVideoFile:\t{VideoFile}\nImage Frame:\t{ImageFrame}\nHydro:\t\t{HydrationLevel},\nLight:\t\t{LightLevel},\nTemp:\t\t{TemperatureReading},\nHumidity:\t{HumidityReading}";
        }
    }
}
