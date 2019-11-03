using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{

    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;

    TextMesh textMesh;

    void Start()
    {

    }

    void Update()
    {
        Vector3 snap;
        snap.x = Mathf.RoundToInt(transform.position.x / 10f) * gridSize;
        snap.z = Mathf.RoundToInt(transform.position.z / 10f) * gridSize;
        transform.position = new Vector3(snap.x, 0f, snap.z);

        textMesh = GetComponentInChildren<TextMesh>();
        string spot = snap.x / gridSize + ", " + snap.z / gridSize;
        textMesh.text = spot;
        gameObject.name = spot;
    }
}
