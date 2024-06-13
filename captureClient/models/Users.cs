using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace PostgrestExample.models
{
    [Table("users")]
    class User : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("username")]
        public string Username { get; set; } = null!;

        [Column("role")]
        public string Role { get; set; } = null!;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("last_logged_in")]
        public DateTime LastLoggedIn { get; set; }
    }
}
