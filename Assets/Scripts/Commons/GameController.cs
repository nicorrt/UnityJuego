using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    public static bool gameOn = false;
    private SpriteRenderer sprfundidoNegro;
    [SerializeField] private GameObject fundidoNegro;
    [SerializeField] private GameObject camara;
    private AudioSource cancion;
    static GameController current;


    private void Awake(){
        current = this;
        fundidoNegro.SetActive(true);
    }

    private void Start(){
        sprfundidoNegro = fundidoNegro.GetComponent<SpriteRenderer>();
        cancion = camara.GetComponent<AudioSource>();
        //camara = GetComponent<GameObject>();
        Invoke("QuitaFundido", 0.5f);
        cancion.Play();
    }

    public static void recargaEscena(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void QuitaFundido(){
        StartCoroutine("QuitaFC");
    }

    IEnumerator QuitaFC(){
        for(float alpha = 1f; alpha>=0;alpha -= Time.deltaTime*2f){
            sprfundidoNegro.material.color = new Color(sprfundidoNegro.material.color.r, sprfundidoNegro.material.color.g,
            sprfundidoNegro.material.color.b, alpha);
            yield return null;
        }
        gameOn=true;
    }
}
