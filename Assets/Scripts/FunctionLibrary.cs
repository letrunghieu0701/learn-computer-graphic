
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public delegate float MathFunction(float pos_x, float pos_z, float time);

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

    public static float SinWave(float pos_x, float pos_z, float time)
    {
        float y = Sin(PI * (pos_x + pos_z + + time));
        //float y = Sin(pos_x + Time.time);
        //float y = Sin(PI * pos_x + time);
        return y;
    }

    public static float MultiWave(float pos_x, float pos_z, float time)
    {
        float y = Sin(PI * (pos_x + time));
        y += 0.5f * Sin(2f * PI * (pos_z + time));
        //return y / 1.5f; // 1.5 = sin + 0.5sin <=> [-1.5; 1.5]
        y += Sin(PI * (pos_x + pos_z + 0.25f * time));
        return y / 2.5f; // 2.5 = sin + 0.5sin + sin <=> [-2.5; 2.5]
    }

    public static float Ripple(float pos_x, float pos_z, float time)
    {
        float d = Mathf.Sqrt(pos_x * pos_x + pos_z * pos_z);
        float y = Sin(PI * (4 * d - time)) / (1f + 10f * d);
        return y;
    }
}
