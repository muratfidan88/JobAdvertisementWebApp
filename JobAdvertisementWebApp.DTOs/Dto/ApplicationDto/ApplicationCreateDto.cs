﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.DTOs
{
    public class ApplicationCreateDto : IDto
    {
        public int AdvertisementId { get; set; }
        public int UserId { get; set; }
    }
}