using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapeRecorderButtons : MonoBehaviour
{

    //public Button pauseButton;
    private PlayerCollisions playerColl;

    void Start()
    {
        Time.timeScale = 1f;
        //pauseButton.onClick.AddListener(TaskOnClick);
        playerColl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisions>();

    }
    private void Update()
    {
        if(!playerColl.canUseButtons)
            Time.timeScale = 1f;
    }
    public void PauseBtnPressed()
    {
        if(playerColl.canUseButtons)
            Time.timeScale = 0.5f;
        // Stop the musics as well
        // Commnunicate with the SFX manager here
    }

    public void ResumeGameBtnPressd()
    {
        if (playerColl.canUseButtons)
            Time.timeScale = 1f;
    }

    public void ForwardBtnPressed()
    {
        if (playerColl.canUseButtons)
            Time.timeScale = 2f;
    }

    //private void TaskOnClick()
    //{
    //    Debug.Log("You have clicked the button!");
    //}
}
