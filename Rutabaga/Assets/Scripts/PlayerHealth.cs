using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int curHealth;

    public Animator checkpointAnim;
    public HUD hud;
    public CheckpointManager checkpointM;

    public bool immune;
    public float immuneTime = 0.3f;
    public Color hurtColor;
    public Color normalColor;
    public SpriteRenderer spr;

    public MovementController pm;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        if(hud == null) hud = GameObject.FindGameObjectsWithTag("HUD")[0].GetComponent<HUD>();

        spr = GetComponent<SpriteRenderer>();
        immune = false;
        normalColor = spr.color;

        pm = GetComponent<MovementController>();
    }

    public void TakeDamage(int dmg){
        if(!immune || dmg<0) SetHealth(curHealth - dmg);
    } 

    public void Respawn(){
        Debug.Log("Respawn");
        checkpointAnim.SetTrigger("Flash");
        transform.position = new Vector3 (checkpointM.checkpoints[checkpointM.currentCheckpoint].transform.position.x, -4.065f, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
        pm.RemoveHook();
    }

    void Die(){
        Debug.Log("You ran out of health!");
        Respawn();
        ResetHealth();
    }

    public void ResetHealth(){
        SetHealth(maxHealth);
    }

    public void SetImmune(){
        immune = true;
        spr.color = hurtColor;
        Invoke("SetNotImmune",immuneTime);
    }

    public void SetNotImmune(){
        immune = false;
        spr.color = normalColor;
    }

    public void SetHealth(int h){
        bool willBeImmune = false;
        if(h<curHealth){
            willBeImmune = true;
        }
        curHealth = Mathf.Max(h,0);
        curHealth = Mathf.Min(h,maxHealth);
        hud.SetHealth(curHealth);
        if(curHealth == 0){
            Die();
        }
        else if (willBeImmune){
            SetImmune();
        }
    }


}
