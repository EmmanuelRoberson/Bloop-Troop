using UnityEngine;

namespace Emmanuel
{
    public static class CustomMath
    {
        // Bezier Curve functions

        public static float LinearBezier(float portion, float start, float end)
        {
            float portionRemaining = 1 - portion;

            return (portionRemaining * start) + (portion * end);
        }

        public static float QuadBezier(float portion, float start, float midPointA, float end)
        {
            float portionRemaining = 1 - portion;

            return (Mathf.Pow(portionRemaining, 2) * start)
                   + (2 * portionRemaining * portion * midPointA * end)
                   + (Mathf.Pow(portion, 2));

        }

    }
}
