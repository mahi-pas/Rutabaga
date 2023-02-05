using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damage;
    public bool respawnsPlayer;
    public bool destroySelf;
    public GameObject destructionPrefab;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();
            if(ph == null) return;
            ph.TakeDamage(damage);
            if(respawnsPlayer) ph.Respawn();
            if(destroySelf){
                if(destructionPrefab!=null) Instantiate(destructionPrefab);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();
            if(ph == null) return;
            ph.TakeDamage(damage);
            if(respawnsPlayer) ph.Respawn();
            if(destroySelf){
                if(destructionPrefab!=null) Instantiate(destructionPrefab);
                Destroy(gameObject);
            }
        }
    }
}
