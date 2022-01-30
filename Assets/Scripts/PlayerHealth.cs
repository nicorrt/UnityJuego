using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public Image healthImg;
    public float maxHealth;
    private bool isInmune;
    public float inmuneTime;
    public float knockbackForceX;
    public float knockbackForceY;
    Blink material;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    Animator anim;
    public GameObject sonidoMuerte;
    private AudioSource muerteAudio;

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        material = GetComponent<Blink>();
        sprite = GetComponent<SpriteRenderer>();
        material.original = sprite.material;
        anim = GetComponent<Animator>();
        muerteAudio = sonidoMuerte.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        healthImg.fillAmount = health/100;
        if(health>maxHealth){
            health = maxHealth;
        }
        if(health<=0){
            //GameOver o Empieza de nuevo
            diedPlayer();
            Invoke("VueltaConTiempo", 1);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("EnemigoG")&&!isInmune){
            health -= collision.GetComponent<Enemy>().damage;
            StartCoroutine(Inmunity());
            if(collision.transform.position.x>transform.position.x){
                rb.AddForce(new Vector2(-knockbackForceX,knockbackForceY), ForceMode2D.Force);
            }else{
                rb.AddForce(new Vector2(knockbackForceX,knockbackForceY), ForceMode2D.Force);
            }

        }

        if(collision.gameObject.tag == "Pinchos"){
            health = - 20;
        }

        if(collision.gameObject.tag == "Caida"){
            health = - 50;
        }

    }

    private void diedPlayer(){
        muerteAudio.Play();
        anim.Play("Muerte");
        GameController.gameOn = false;    
    }

    private void VueltaConTiempo(){
        GameController.recargaEscena();
    }

    IEnumerator Inmunity(){
        isInmune=true;
        sprite.material = material.blinke;
        yield return new WaitForSeconds(inmuneTime);
        sprite.material = material.original;
        isInmune = false;
    }


}
