using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public static float SinWave(float pos_x, float time)
    {
        float y = Sin(PI * (pos_x + time));
        return y;
    }

    public static float MultiWave(float pos_x, float time)
    {
        float y = Sin(PI * (pos_x + time));
        y += 0.5f * Sin(2f * PI * (pos_x + time));
        return y * (2f / 3f);
    }
}
