using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damage;
    public bool respawnsPlayer;
    public bool destroySelf;
    public GameObject destructionPrefab;
    public AudioSource hitSound;
    public float prefabDestroyTime = 2f;

    public virtual void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();
            Damage(ph);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();
            Damage(ph);
        }
    }

    public void Damage(PlayerHealth ph){
        if(ph == null) return;
        ph.TakeDamage(damage);
        if(respawnsPlayer) ph.Respawn();
        if(destroySelf){
            DestroySelf();
        }
    }

    public void DestroySelf(){
        if(destructionPrefab!=null){
            GameObject pf = Instantiate(destructionPrefab);
            pf.transform.position = transform.position;
            pf.transform.rotation = transform.rotation;
            pf.transform.localScale = transform.localScale;
            Destroy(pf,prefabDestroyTime);
        }
        if(hitSound!=null) hitSound.Play();
        Destroy(gameObject);
    }
}
