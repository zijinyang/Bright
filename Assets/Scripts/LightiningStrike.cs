using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightiningStrike : MonoBehaviour
{
    public int PosSize;
    public bool useArcing;
    public bool useSine;
    public bool useWiggle;
    public bool X, Y;
    [Range(-1, 1)]
    public float _ArcingPowParam1;
    [Range(0, 5)]
    public float _SineScaleX;
    public float _SineScaleY;
    public float _CenterOffset;
    public float _Adjust;
    public float _RandomSize;
    public float _Speed;

    LineRenderer lineRenderer;
    List<Vector3> posList = new List<Vector3>();
    [System.NonSerialized] public Vector3 startPos;
    [System.NonSerialized] public Vector3 endPos;
    float fps;
    float sineRandom;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        startPos = lineRenderer.GetPosition(0);
        endPos = lineRenderer.GetPosition(1);
        LerpPos();
    }

    void Update()
    {
        fps += Time.deltaTime * _Speed;
        if (fps >= 1)
        {
            sineRandom = (float)Random.Range(0, posList.Count * 10) / 10;
            fps = 0;
        }

        List<Vector3> list = new List<Vector3>();
        list.Add(startPos);

        float totalHeight = startPos.y - endPos.y;  // This would be 5 (from Y=5 to Y=0)

        for (int i = 1; i < posList.Count - 1; i++)
        {
            Vector3 point = posList[i];
            float normalizedHeight = (float)i / (posList.Count - 1); // Will go from 0 to 1
            float baseY = Mathf.Lerp(startPos.y, endPos.y, normalizedHeight);
            if (useArcing)
            {
                Vector3 v = new Vector3();
                if (X) v.x = Arcing(i);
                if (Y) v.y = Arcing(i) * (totalHeight * 0.2f); // Use percentage of total height
                point = Vector3.Lerp(posList[i], posList[i] + v, fps);
            }
            if (useSine && i != 0 && i != posList.Count - 1)
            {
                Vector3 v = new Vector3();
                if (X) v.x = Sine(i + sineRandom);
                if (Y) v.y = Sine(i + sineRandom) * (totalHeight * 0.15f);

                point += v;
            }
            if (useWiggle && i != 0 && i != posList.Count - 1)
            {
                Vector3 wiggle = Wiggle(i);
                wiggle.y *= 0.1f;
                point += Wiggle(i);
            }

            float heightRange = totalHeight * 0.3f; // Allow movement within 30% of total height
            float currentSegmentMax = baseY + heightRange;
            float currentSegmentMin = baseY - heightRange;

            // Keep within the overall bounds
            currentSegmentMax = Mathf.Min(currentSegmentMax, startPos.y);
            currentSegmentMin = Mathf.Max(currentSegmentMin, endPos.y);

            point.y = Mathf.Max(currentSegmentMin, Mathf.Min(currentSegmentMax, point.y));

            list.Add(point);
        }
        list.Add(endPos);  // Keep end fixed
        SetLinePosition(list);
    }

    void SetLinePosition(List<Vector3> listPoint)
    {
        lineRenderer.positionCount = listPoint.Count;
        for (int i = 0; i < listPoint.Count; i++)
        {
            lineRenderer.SetPosition(i, listPoint[i]);
        }
    }

    public void LerpPos()
    {
        int index = PosSize + 2;
        for (int i = 0; i < index; i++)
        {
            if (posList.Count < index)
                posList.Add(Vector3.Lerp(startPos, endPos, (float)i / index));
            else posList[i] = Vector3.Lerp(startPos, endPos, (float)i / index);
        }
    }

    float Arcing(float param)
    {
        return _ArcingPowParam1 * Mathf.Pow((param - (float)posList.Count / 2 + _CenterOffset) * _ArcingPowParam1, 2) + _Adjust;
    }


    float Sine(float param)
    {
        return Mathf.Sin((float)param / posList.Count * 2 * 3.14f * _SineScaleX) * _SineScaleY;
    }

    Vector3 Wiggle(int listIndex)
    {
        Vector3 v = new Vector3();
        if (X) v.x = Random.Range(0, 10) * _RandomSize;
        if (Y) v.y = Random.Range(0, 10) * _RandomSize;
        return v;
    }
}
