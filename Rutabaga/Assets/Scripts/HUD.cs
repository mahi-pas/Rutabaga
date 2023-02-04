using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public int health;

    public List<Image> hearts;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if(i<health){
                hearts[i].enabled = true;
            }
            else{
                hearts[i].enabled = false;
            }
        }
    }

    public void SetHealth(int h){
        health = h;
        if(health>hearts.Count){
            health = hearts.Count;
        }
    }
}
