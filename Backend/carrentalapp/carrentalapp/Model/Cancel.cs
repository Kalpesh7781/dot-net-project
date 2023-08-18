using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carrentalapp.Model
{
    public class Cancel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long booking_id { get; set; }
        public DateTime? rentalDate { get; set; }

        public DateTime? returndate { get; set; }

        public long? car_id { get; set; }

        public long? user_no { get; set; }

        public virtual Car? car { get; set; }

        public virtual User? user { get; set; }
        public int ammt { get; set; }

    }
}
