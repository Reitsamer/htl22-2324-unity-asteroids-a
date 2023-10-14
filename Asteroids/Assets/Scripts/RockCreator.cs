using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RockCreator : MonoBehaviour
{
    public LineRenderer lineRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        GenerateGeometry();
    }

    private void GenerateGeometry()
    {
        lr.positionCount=vertices;
        lr.startWidth=0.25f;
        lr.endWidth=0.25f;
        //Quaternion rotate=Quaternion.Euler(0,0,360/Vertices);
        Vector3[] positions=new Vector3[vertices];
        positions[0]=initialPos;
        for(int i=1;i<vertices;i++)
        {
            positions[i]=Quaternion.Euler(0,0,360*i/vertices)*initialPos;
            float deformation = randomStartDeformation + Time.time * speed;
            float offset = Mathf.PerlinNoise(
                positions[i].x + deformation, 
                positions[i].y + deformation ) * threshold;
            float remappedOffset = math.remap(0f, 1f, -1f, 1f, offset);
            positions[i].x += remappedOffset;
            positions[i].y += remappedOffset;
        }
        lr.SetPositions(positions);
        lr.loop=true;
    }
}
