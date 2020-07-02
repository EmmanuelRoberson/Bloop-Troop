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

        public static float CubicBezier(float portion, float start, float midPointA, float midPointB, float end)
        {
            float portionRemaining = 1 - portion;

            float termOne = Mathf.Pow(portionRemaining, 3) * start;
            float termTwo = 3 * Mathf.Pow(portionRemaining, 2) * portion * midPointA;
            float termThree = 3 * portionRemaining * Mathf.Pow(portion, 2) * midPointB;
            float termFour = Mathf.Pow(portion, 3) * end;

            return termOne + termTwo + termThree + termFour;
        }

    }
}
