﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class BaseDTO
    {
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
