using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int curHealth;

    public HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        if(hud == null) hud = GameObject.FindGameObjectsWithTag("HUD")[0].GetComponent<HUD>();
    }

    public void TakeDamage(int dmg){
        SetHealth(curHealth - dmg);
    } 

    public void Respawn(){
        Debug.Log("Respawn");
    }

    void Die(){
        Debug.Log("You ran out of health!");
    }

    public void ResetHealth(){
        SetHealth(maxHealth);
    }

    public void SetHealth(int h){
        curHealth = Mathf.Max(h,0);
        curHealth = Mathf.Min(h,maxHealth);
        hud.SetHealth(curHealth);
        if(curHealth == 0){
            Die();
        }
    }


}
