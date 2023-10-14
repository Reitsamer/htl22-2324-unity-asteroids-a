using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RockCreator : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int vertices;
    public float lineWidth;
    public Vector3 initialPos;
    public float speed;

    public float randomStartDeformation;
    public float threshold;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        GenerateGeometry();
    }

    private void GenerateGeometry()
    {
        lineRenderer.positionCount=vertices;
        lineRenderer.startWidth=lineWidth;
        lineRenderer.endWidth=lineWidth;
        //Quaternion rotate=Quaternion.Euler(0,0,360/Vertices);
        Vector3[] positions=new Vector3[vertices];
        positions[0]=initialPos;
        for(int i=1;i<vertices;i++)
        {
            positions[i]=Quaternion.Euler(0,0,(360f*i)/vertices)*initialPos;
            
            float deformation = randomStartDeformation + Time.time * speed;
            float offset = Mathf.PerlinNoise(
                positions[i].x + deformation, 
                positions[i].y + deformation ) * threshold;
            float remappedOffset = math.remap(0f, 1f, -1f, 1f, offset);
            positions[i].x += remappedOffset;
            positions[i].y += remappedOffset;
            
            Debug.Log(positions[i]);
        }
        lineRenderer.SetPositions(positions);
        lineRenderer.loop=true;
        lineRenderer.useWorldSpace = false;

       
    }

    private void OnValidate()
    {
        GenerateGeometry();
    }
}
