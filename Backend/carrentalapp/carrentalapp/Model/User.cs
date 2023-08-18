using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace carrentalapp.Model
{
    public class User
    {
        public string? user_nm { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long user_no { get; set; }
        public string? user_email { get; set; }
        public DateTime? user_dob { get; set; }
        public string? user_gender { get; set; }

        public string? user_address { get; set; } 
        public string? user_city { get; set; }
        public string? user_state { get; set; }
        public int? user_zip { get; set; }
        public long? user_adhar { get; set; }
        public string? user_password { get; set; }
        [JsonIgnore]
        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
