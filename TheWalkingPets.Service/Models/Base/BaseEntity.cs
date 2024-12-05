﻿using System.ComponentModel.DataAnnotations;

namespace TheWalkingPets.Service.Models.Base
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public  DateTime CreatedAt {  get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
