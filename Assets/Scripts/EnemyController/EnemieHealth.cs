using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieHealth : MonoBehaviour
{
  Enemy enemy;
  public bool isDamaged;
  public Animator animator;  
  private SpriteRenderer sprite;
  private Blink blink;
  private Rigidbody2D rb;



  public void Start(){
      enemy = GetComponent<Enemy>();
      sprite = GetComponent<SpriteRenderer>();
      blink = GetComponent<Blink>();
      rb = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
  }

  public void OnTriggerEnter2D(Collider2D collision){
      if(collision.CompareTag("Weapon")&&!isDamaged){
          enemy.healthPoint -= 2f;
          if(collision.transform.position.x <transform.position.x){
                        rb.AddForce(new Vector2(enemy.knockbackForceX,enemy.knockbackForceY), ForceMode2D.Force);
          }else{
                        rb.AddForce(new Vector2(-enemy.knockbackForceX,enemy.knockbackForceY), ForceMode2D.Force);
          }
          StartCoroutine(Damager());
          if(enemy.healthPoint <=0){
              animator.SetBool("isDeath", true);
              //Instantiate(animator, transform.position,Quaternion.identity);
              Destroy(gameObject);
          }
      }
  }



  IEnumerator Damager(){
      isDamaged = true;
      sprite.material = blink.blinke;
      yield return new WaitForSeconds(0.5f);
      isDamaged = false;
      sprite.material = blink.original;
  }

}
