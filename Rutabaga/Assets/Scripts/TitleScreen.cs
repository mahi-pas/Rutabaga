using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameObject levelSelect;
    public GameObject titleScreen;

    private void Start() {
        ShowTitle();
    }

    public void ShowLevels(){
        titleScreen.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void ShowTitle(){
        titleScreen.SetActive(true);
        levelSelect.SetActive(false);
    }

}
