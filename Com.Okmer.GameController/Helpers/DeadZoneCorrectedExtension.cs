using System;
using System.Numerics;

namespace Com.Okmer.GameController.Helpers
{
    public static class DeadZoneCorrectedExtension
    {
        public static float DeadZoneCorrected(this float value, float deadZone)
        {
            return (Math.Abs(value) > deadZone) ? value : 0.0f;
        }

        public static Vector2 DeadZoneCorrected(this Vector2 vector, float deadZone)
        {
            return new Vector2(vector.X.DeadZoneCorrected(deadZone), vector.Y.DeadZoneCorrected(deadZone));
        }
    }
}
