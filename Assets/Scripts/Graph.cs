using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public enum GraphFunction
    {
        Sin = 1,
        Multi = 2,
    };

    [SerializeField]
    private Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    private int resolution = 10;

    [SerializeField]
    private GraphFunction graphFunction = GraphFunction.Sin;

    Transform[] points;
    private void Awake()
    {
        points = new Transform[resolution];

        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        Vector3 scale = Vector3.one * step;
        Transform point;
        for (int i = 0; i < resolution; i++)
        {
            position.x = (i + 0.5f) * step - 1f;

            points[i] = point = Instantiate(pointPrefab);
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(this.transform, false);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        Transform point;
        Vector3 position;
        for (int i = 0; i < points.Length; i++)
        {
            point = points[i];
            position = point.localPosition;
            switch (graphFunction)
            {
                case GraphFunction.Sin:
                    position.y = FunctionLibrary.SinWave(position.x, Time.time);
                    break;
                case GraphFunction.Multi:
                    position.y = FunctionLibrary.MultiWave(position.x, Time.time);
                    break;
                default:
                    position.y = FunctionLibrary.SinWave(position.x, Time.time);
                    break;
            }
            point.localPosition = position;
        }
    }
}
