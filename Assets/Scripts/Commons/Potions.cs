using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
        public float healthPoints;
        private AudioSource sonido;


        private void Awake(){
           sonido = GetComponent<AudioSource>(); 
        }
        private void OnTriggerEnter2D(Collider2D collision){
            collision.GetComponent<PlayerHealth>().health += healthPoints;
            sonido.Play();
            Destroy(gameObject);
        }

}
