using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public interface IEntity
    {
        DateTime DbCreationDate { get; set; }
        DateTime? DbUpdateDate { get; set; }
    }
}
