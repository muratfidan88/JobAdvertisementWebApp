using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.DTOs
{
    public interface IUpdateDto : IDto
    {
        public int Id { get; set; }
    }
}
