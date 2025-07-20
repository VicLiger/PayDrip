using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayDrip.Domain.Interfaces.Models
{
    public interface IChargeable
    {
        decimal GetAmount();
        string GetDescription();
    }
}
