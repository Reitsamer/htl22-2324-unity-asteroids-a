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
        lineRenderer.positionCount = 3;
        lineRenderer.startWidth = 0.25f;
        lineRenderer.endWidth = 0.25f;
        lineRenderer.useWorldSpace = false;

        Vector3[] positions = new Vector3[3];
        // positions[0] = new Vector3(0, height * 0.5f, 0);
        // positions[1] = new Vector3(-width * 0.5f, -height * 0.5f, 0);
        // positions[2] = new Vector3(width * 0.5f, -height * 0.5f, 0);

        lineRenderer.SetPositions(positions);
        lineRenderer.loop = true;

        // if (Application.isPlaying)
        //     StartCoroutine(SetupEnginePosition(positions));
        //
        // spawnPoint = positions[0];
    }
}
