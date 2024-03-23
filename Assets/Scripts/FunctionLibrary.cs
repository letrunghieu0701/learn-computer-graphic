
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public delegate float MathFunction(float pos_x, float time);

    public enum FunctionName
    {
        Sin = 1,
        Multi = 2,
        Ripple = 3,
    };

    private static Dictionary<FunctionName, MathFunction> mathFunctions = new Dictionary<FunctionName, MathFunction>()
    {
        { FunctionName.Sin, SinWave },
        { FunctionName.Multi, MultiWave },
        { FunctionName.Ripple, Ripple },
    };

    public static MathFunction GetFunction(FunctionName functionName)
    {
        return mathFunctions[functionName];
    }

    public static float SinWave(float pos_x, float time)
    {
        //float y = Sin(PI * (pos_x + time));
        //float y = Sin(pos_x + Time.time);
        float y = Sin(PI * pos_x + time);
        return y;
    }

    public static float MultiWave(float pos_x, float time)
    {
        float y = Sin(PI * (pos_x + time));
        y += 0.5f * Sin(2f * PI * (pos_x + time));
        return y * (2f / 3f);
    }

    public static float Ripple(float pos_x, float time)
    {
        float d = Mathf.Abs(pos_x);
        float y = Sin(PI * (4 * d - time)) / (1f + 10f * d);
        return y;
    }
}
