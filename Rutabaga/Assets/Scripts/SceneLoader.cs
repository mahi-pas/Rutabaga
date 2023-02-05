using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void startLevel(int lvl){
        SceneManager.LoadScene(lvl);
    }
    public void startTitle(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
