using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform origen;
    [SerializeField] private Transform destino;

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(origen.position,0.1f);
        Gizmos.DrawSphere(destino.position,0.1f);
    }
}
