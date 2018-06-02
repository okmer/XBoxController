using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteintjeControllerFun.Models
{
    public class SunModel : MoveModel
    {
        private const double HalfPi = 0.5 * Math.PI;

        public override double Value
        {
            set
            {
                base.Value = value;

                OffsetX = Value;
                OffsetY = Math.Sin(Value * HalfPi);
            }
        }
    }
}
