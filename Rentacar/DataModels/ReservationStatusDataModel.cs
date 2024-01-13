﻿using System.ComponentModel.DataAnnotations;

namespace Rentacar.DataModels
{
    public class ReservationStatusDataModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(1), MaxLength(20)]
        public string Value { get; set; }
    }
}
