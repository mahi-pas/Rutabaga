using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool paused = false;
    
    public void Pause(){
        paused = true;
        Time.timeScale = 0;
    }

    public void Unpause(){
        paused = false;
        Time.timeScale = 1;
    }

    public void FlipPause(){
        paused = !paused;
            if(paused){
                Time.timeScale = 0;
            }
            else{
                Time.timeScale = 1;
            }
    }

    
}
