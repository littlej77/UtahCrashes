using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UtahCrashes.Models
{
    public class Crash
    {
        [Key]
        [Required]
        public string Crash_ID { get; set; }
        public DateTime Crash_DateTime { get; set; }
        public string Route { get; set; }
        public double MilePoint { get; set; }

        public double Lat_Utm_Y { get; set; }
        public double Long_Utm_X { get; set; }
        public string Main_Road_Name { get; set; }
        public string City { get; set; }
        public string County_Name { get; set; }
        public int Crash_Severity_ID { get; set; }

        public int Work_Zone_Related { get; set; }
        public int Pedestrian_Involved { get; set; }
        public int Bicyclist_Involved { get; set; }
        public int Motorcycles_Involved { get; set; }
        public int Improper_Restraint { get; set; }
        public int Unrestrained { get; set; }
        public int DUI { get; set; }
        public int Intersection_Related { get; set; }
        public int Wild_Animal_Related { get; set; }
        public int Domestic_Animal_Related { get; set; }
        public int Overturn_Rollover { get; set; }
        public int Commercial_Motor_Veh_Involved { get; set; }
        public int Teenage_Driver_Involved { get; set; }

        public int Older_Driver_Involved { get; set; }
        public int Night_Dark_Condition { get; set; }
        public int Single_Vehicle { get; set; }
        public int Distracted_Driving { get; set; }
        public int Drowsy_Driving { get; set; }
        public int Roadway_Departure { get; set; }
    }
}
