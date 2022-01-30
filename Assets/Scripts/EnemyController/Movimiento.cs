using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private Transform[] puntosMov;
  [SerializeField] private float velocidad;

  private Vector3 posIni, posTemp;
  private float posDer = -1;

  private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        posIni = transform.localScale;
    }

    
      void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, puntosMov[i].transform.position, velocidad * Time.deltaTime); 
       if(Vector2.Distance(transform.position,puntosMov[i].transform.position)<0.1f){
           if(puntosMov[i]!=puntosMov[puntosMov.Length-1]){
               i++;
           }else{
               i=0;
           }

           posDer = Mathf.Sign(puntosMov[i].transform.position.x - transform.position.x);
           gira(posDer);
       }
    }

    private void gira(float lado){
        if(posDer == -1){
            posTemp = transform.localScale;
            posTemp.x = posTemp.x * -1;
        }else{
            posTemp = posIni;
        }
        transform.localScale = posTemp;
    }
}
