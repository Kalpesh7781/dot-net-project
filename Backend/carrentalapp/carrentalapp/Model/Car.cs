using System.Text.Json.Serialization;
using carrentalapp.Data;

namespace carrentalapp.Model
{
    public class Car
    {
        public long id { get; set; }
        public string? car_nm { get; set; }


        public string? car_brnd { get; set; }
        public string? car_no { get; set; }
        public int? car_model { get; set; }
        public int? car_milage { get; set; }
        public int? car_rate { get; set; }
        public string? car_varient { get; set; }
        public string? car_capacity { get; set; }
        public string? car_ac { get; set; }

        public string? car_address { get; set; }





        public string? car_city { get; set; }

        public string? car_img { get; set; }











        public string? car_status { get; set; }



        [JsonIgnore]
        public virtual ICollection<Booking>? Bookings { get; set; }


    }


}
