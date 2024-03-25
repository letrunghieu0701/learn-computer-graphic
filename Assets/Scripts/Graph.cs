using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    private Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    private int resolution = 10;

    [SerializeField]
    private FunctionLibrary.FunctionName graphFunction = FunctionLibrary.FunctionName.Sin;

    Transform[] points;
    private void Awake()
    {
        points = new Transform[resolution * resolution];

        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Transform point;
        for (int i = 0, x = 0, z = 0; i < resolution * resolution; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z += 1;
            }

            points[i] = point = Instantiate(pointPrefab);
            point.localScale = scale;
            point.SetParent(this.transform, false);
        }
    }

    void Update()
    {
        FunctionLibrary.MathFunction mathFunc = FunctionLibrary.GetFunction(graphFunction);
        float time = Time.time;
        float step = 2f / resolution;

        float v = 0.5f * step - 1f;
        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z += 1;
                v = (z + 0.5f) * step - 1f;
            }
            float u = (x + 0.5f) * step - 1f;
            points[i].localPosition = mathFunc(u, v, time);
        }
    }
}
