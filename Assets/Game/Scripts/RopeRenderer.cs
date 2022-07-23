using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class RopeRenderer : MonoBehaviour
{
    [SerializeField] private Transform[] ropeSegments;
    [SerializeField] private List<Vector3> ropeSegmentPositions;
    
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>(); 
        foreach (var segment in ropeSegments)
        {
            ropeSegmentPositions.Add(segment.position);
        }
    }

    private void Update()
    {
        _lineRenderer.SetPositions(ropeSegmentPositions.ToArray());
    }
}
