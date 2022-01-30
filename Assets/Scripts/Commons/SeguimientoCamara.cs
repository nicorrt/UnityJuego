using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{

    public Vector2 minCamPos, maxCamPos;
    public GameObject seguir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float floatX = seguir.transform.position.x;
        float floatY = seguir.transform.position.y;

        transform.position = new Vector3 (
            Mathf.Clamp(floatX, minCamPos.x,maxCamPos.x),
            Mathf.Clamp(floatY, minCamPos.y,maxCamPos.y)
            ,transform.position.z);
    }
}
