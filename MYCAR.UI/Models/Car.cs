using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MYCAR.UI.Models
{
    [JsonObject]
    public class Car
    {
        [JsonProperty("Photo")]
        public string Photo { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Brand")]
        public string Brand { get; set; }
        
        [JsonProperty("CarModel")]
        public string CarModel { get; set; }
        
        [JsonProperty("Drivetrain")]
        public string Drivetrain { get; set; }

        [JsonProperty("Engine")]
        public string Engine { get; set; }

        [JsonProperty("Exterior_color")]
        public string Exterior_color { get; set; }

        [JsonProperty("Fuel_type")]
        public string Fuel_type { get; set; }

        [JsonProperty("Interior_color")]
        public string Interior_color { get; set; }

        [JsonProperty("MPG")]
        public string MPG { get; set; }

        [JsonProperty("Mileage")]
        public string Mileage { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }

        [JsonProperty("Stock")]
        public string Stock { get; set; }

        [JsonProperty("Transmission")]
        public string Transmission { get; set; }

        [JsonProperty("VIN")]
        public string VIN { get; set; }

        [JsonProperty("Vehicle_history")]
        public string Vehicle_history { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }
    }
}

/*
 

{
  "cars": {
    "0": {
      "Brand": "Ford", 
      "CarModel": "Edge", 
      "Drivetrain": "All-wheel Drive", 
      "Engine": "3.5L V6 24V MPFI DOHC", 
      "Exterior color": "Ruby Red Metallic Tinted Clearcoat", 
      "Fuel type": "Gasoline", 
      "Interior color": "Ebony", 
      "MPG": "20\u201327", 
      "Mileage": "19,794 mi.", 
      "Price": "$34,390", 
      "Stock #": "J433", 
      "Transmission": "6-Speed Automatic", 
      "VIN": "2FMPK4K8XJBB70896", 
      "Vehicle history": "CARFAX Report", 
      "Year": "2018"
    }, 
    "1": {
      "Brand": "Ford", 
      "CarModel": "Escape", 
      "Drivetrain": "Four-wheel Drive", 
      "Engine": "1.5L I4 16V GDI DOHC Turbo", 
      "Exterior color": "Black", 
      "Fuel type": "Gasoline", 
      "Interior color": "Charcoal Black", 
      "MPG": "22\u201328", 
      "Mileage": "36,667 mi.", 
      "Price": "$27,884", 
      "Stock #": "T4064A", 
      "Transmission": "6-Speed Automatic", 
      "VIN": "1FMCU9HD2JUC87022", 
      "Vehicle history": "Free CARFAX Report", 
      "Year": "2018"
    }, 
    "2": {
      "Brand": "Ford", 
      "CarModel": "Escape", 
      "Drivetrain": "Front-wheel Drive", 
      "Engine": "1.5L I4 16V GDI DOHC Turbo", 
      "Exterior color": "Oxford White", 
      "Fuel type": "Gasoline", 
      "Interior color": "Charcoal Black", 
      "MPG": "23\u201330", 
      "Mileage": "35,073 mi.", 
      "Price": "$23,495", 
      "Stock #": "40896A", 
      "Transmission": "6-Speed Automatic", 
      "VIN": "1FMCU0HD9JUD15801", 
      "Vehicle history": "Free CARFAX 1-Owner Report", 
      "Year": "2018"
    }, 
    "3": {
      "Brand": "Ford", 
      "CarModel": "Explorer", 
      "Drivetrain": "Four-wheel Drive", 
      "Engine": "3.5L V6 24V MPFI DOHC", 
      "Exterior color": "Shadow Black", 
      "Fuel type": "Gasoline", 
      "Interior color": "Ebony Black", 
      "MPG": "16\u201322", 
      "Mileage": "45,573 mi.", 
      "Price": "$34,000", 
      "Stock #": "P7459T", 
      "Transmission": "6-Speed Automatic", 
      "VIN": "1FM5K8D87JGA29014", 
      "Vehicle history": "Free CARFAX Report", 
      "Year": "2018"
    }, 
    "4": {
      "Brand": "Ford", 
      "CarModel": "Escape", 
      "Drivetrain": "Four-wheel Drive", 
      "Engine": "1.5L I4 16V GDI DOHC Turbo", 
      "Exterior color": "Shadow Black", 
      "Fuel type": "Gasoline", 
      "Interior color": "Charcoal Black", 
      "MPG": "22\u201328", 
      "Mileage": "21,771 mi.", 
      "Price": "$22,000", 
      "Stock #": "PD49821", 
      "Transmission": "6-Speed Automatic", 
      "VIN": "1FMCU9GD1JUD49821", 
      "Vehicle history": "Free CARFAX Report", 
      "Year": "2018"
    }
  }
}
 
 
 
 */