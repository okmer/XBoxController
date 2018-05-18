using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController.Helpers
{
    public static class DeadZoneCorrectedExtension
    {
        public static float DeadZoneCorrected(this float value, float deadZone)
        {
            return (Math.Abs(value) > deadZone) ? value : 0.0f;
        }
    }
}
