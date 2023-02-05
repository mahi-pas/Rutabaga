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
        Debug.Log("hit");
        if(other.gameObject.tag == "Player"){
            Debug.Log("hitPlayer");
            PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();
            if(ph == null) return;
            Debug.Log("found PlayerHealth");
            ph.TakeDamage(damage);
            if(respawnsPlayer) ph.Respawn();
            if(destroySelf){
                Instantiate(destructionPrefab);
                Destroy(gameObject);
            }
        }
    }
}
