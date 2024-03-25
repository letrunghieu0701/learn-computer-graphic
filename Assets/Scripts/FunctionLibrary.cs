
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public delegate Vector3 MathFunction(float u, float v, float time);

    public enum FunctionName
    {
        Sin = 1,
        Multi = 2,
        Ripple = 3,
        Circle = 4,
        Cylinder = 5,
        CylinderCollapsingRadius = 6,
        Sphere = 7,
        ScalingSphere = 8,
        SphereVerticalBands = 9,
        SphereHorizontalBands = 10,
        RotatingTwistedSphere = 11,
        SpherePulledApart = 12,
        SelfIntersectingSpindleTorus = 13,
        RingTorus = 14,
        TwistingTorus = 15,
    };

    private static Dictionary<FunctionName, MathFunction> mathFunctions = new Dictionary<FunctionName, MathFunction>()
    {
        { FunctionName.Sin, SinWave },
        { FunctionName.Multi, MultiWave },
        { FunctionName.Ripple, Ripple },
        { FunctionName.Circle, Circle },
        { FunctionName.Cylinder, Cylinder },
        { FunctionName.CylinderCollapsingRadius, CylinderCollapsingRadius },
        { FunctionName.Sphere, Sphere },
        { FunctionName.ScalingSphere, ScalingSphere },
        { FunctionName.SphereVerticalBands, SphereVerticalBands },
        { FunctionName.SphereHorizontalBands, SphereHorizontalBands },
        { FunctionName.RotatingTwistedSphere, RotatingTwistedSphere },
        { FunctionName.SpherePulledApart, SpherePulledApart },
        { FunctionName.SelfIntersectingSpindleTorus, SelfIntersectingSpindleTorus },
        { FunctionName.RingTorus, RingTorus },
        { FunctionName.TwistingTorus, TwistingTorus },

    };

    public static MathFunction GetFunction(FunctionName functionName)
    {
        return mathFunctions[functionName];
    }

    public static Vector3 SinWave(float u, float v, float time)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + v + + time));
        p.z = v;
        //float y = Sin(u + Time.time);
        //float y = Sin(PI * u + time);
        return p;
    }

    public static Vector3 MultiWave(float u, float v, float time)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + time));
        p.y += 0.5f * Sin(2f * PI * (v + time));
        //return y / 1.5f; // 1.5 = sin + 0.5sin <=> [-1.5; 1.5]
        p.y += Sin(PI * (u + v + 0.25f * time));
        p.y /= 2.5f; // 2.5 = sin + 0.5sin + sin <=> [-2.5; 2.5]
        p.z = v;
        return p;
    }

    public static Vector3 Ripple(float u, float v, float time)
    {
        float d = Mathf.Sqrt(u * u + v * v);
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (4 * d - time));
        p.y /= (1f + 10f * d);
        p.z = v;
        return p;
    }

    public static Vector3 Circle(float u, float v, float time)
    {
        Vector3 p;
        p.x = Sin(PI * u);
        p.y = 0f;
        p.z = Cos(PI * u);
        return p;
    }

    public static Vector3 Cylinder(float u, float v, float time)
    {
        Vector3 p;
        p.x = Sin(PI * u);
        p.y = v;
        p.z = Cos(PI * u);
        return p;
    }

    public static Vector3 CylinderCollapsingRadius(float u, float v, float time)
    {
        float r = Cos(0.5f * PI * v);
        Vector3 p;
        p.x = r * Sin(PI * u);
        p.y = v;
        p.z = r * Cos(PI * u);
        return p;
    }

    public static Vector3 Sphere(float u, float v, float time)
    {
        float r = Cos(0.5f * PI * v);
        Vector3 p;
        p.x = r * Sin(PI * u);
        p.y = Sin(v * PI / 2);
        p.z = r * Cos(PI * u);
        return p;
    }

    public static Vector3 ScalingSphere(float u, float v, float time)
    {
        float r = (1 + Sin(PI * time)) / 2;
        float s = r * Cos(PI * v / 2);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(PI * v / 2);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 SphereVerticalBands(float u, float v, float time)
    {
        float r = (9 + Sin(8 * PI * u)) / 10;
        //float r = 0.9f + 0.1f * Sin(8 * PI * u);
        float s = r * Cos(PI * v / 2);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(PI * v / 2);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 SphereHorizontalBands(float u, float v, float time)
    {
        float r = (9 + Sin(8 * PI * v)) / 10;
        //float r = 0.9f + 0.1f * Sin(8 * PI * v);
        float s = r * Cos(PI * v / 2);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(PI * v / 2);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 RotatingTwistedSphere(float u, float v, float time)
    {
        float r = (9 + Sin(PI * (6*u + 4*v + time))) / 10;
        //float r = 0.9f + 0.1f * Sin(8 * PI * v);
        float s = r * Cos(PI * v / 2);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(PI * v / 2);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 SpherePulledApart(float u, float v, float time)
    {
        float r = 1f;
        float s = 0.5f + r * Cos(0.5f * PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(PI * v / 2);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 SelfIntersectingSpindleTorus(float u, float v, float time)
    {
        float r = 1f;
        float s = 0.5f + r * Cos(PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 RingTorus(float u, float v, float time)
    {
        float r1 = 0.75f;
        float r2 = 0.25f;
        float s = r1 + r2 * Cos(PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r2 * Sin(PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 TwistingTorus(float u, float v, float time)
    {
        float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * time));
        float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * time));
        float s = r1 + r2 * Cos(PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r2 * Sin(PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }
}
