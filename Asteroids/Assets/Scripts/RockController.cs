using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    private float leftScreenEdge;
    private float rightScreenEdge;
    
    // Start is called before the first frame update
    void Start()
    {
        leftScreenEdge = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, 0)).x;
        rightScreenEdge = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, 0)).x;
    }

    private void RecalculateBoundingBox()
    {
        LineRenderer renderer = GetComponent<LineRenderer>();
        Vector3[] positions = new Vector3[renderer.positionCount];
        renderer.GetPositions(positions);

        xMin = float.MaxValue;
        xMax = float.MinValue;
        yMin = float.MaxValue;
        yMax = float.MinValue;

        for (int i = 0; i < positions.Length; i++)
        {
            if (xMin > positions[i].x) 
                xMin = positions[i].x;

            // xMin = Math.Min(xMin, positions[i].x);
            
            xMax = Math.Max(xMax, positions[i].x);
            yMin = Math.Min(yMin, positions[i].y);
            yMax = Math.Max(yMax, positions[i].y);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position += direction.normalized * Time.deltaTime * speed;
        
        RecalculateBoundingBox();

        if (direction.normalized.x < 0)
        {
            if (transform.position.x + (xMax - xMin) / 2 < leftScreenEdge)
            {
                transform.position = new Vector3(
                    rightScreenEdge + (xMax - xMin) / 2,
                    transform.position.y,
                    transform.position.z);
            }
        }
        else
        {
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(    // left
            transform.position + new Vector3(xMin, yMin),
            transform.position + new Vector3(xMin, yMax));
        
        Gizmos.DrawLine(    // top
            transform.position + new Vector3(xMin, yMax),
            transform.position + new Vector3(xMax, yMax));
        
        Gizmos.DrawLine(    // right
            transform.position + new Vector3(xMax, yMax),
            transform.position + new Vector3(xMax, yMin));
        
        Gizmos.DrawLine(    // bottom
            transform.position + new Vector3(xMax, yMin),
            transform.position + new Vector3(xMin, yMin));
        
    }
}
