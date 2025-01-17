﻿using System.ComponentModel.DataAnnotations;

namespace Exam.Business.ViewModels.SettingVMs
{
    public class SettingListItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
