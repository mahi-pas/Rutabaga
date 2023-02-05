using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public int health;

    public List<Image> hearts;

    public bool paused;
    public GameObject pauseMenu;
    public PauseManager pm;

    private void Start() {
        pm = GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)){ 
            FlipPause();
        }
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

    public void FlipPause(){
        if(pm.paused){
            Unpause();
        }
        else{
            Pause();
        }
    }

    public void Pause(){
        Debug.Log("Pause");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pm.Pause();
        pauseMenu.SetActive(true);
    }

    public void Unpause(){
        Debug.Log("Unpause");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pm.Unpause();
        pauseMenu.SetActive(false);
    }
}
