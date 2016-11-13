using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {

    public Text currency;
    public Text timeRender;
    public int gameTime;
    public GameObject world;
    public GameObject camera;
    public GameObject pauseOverlay;
    public GameObject resumeOverlay;
    public GameObject ExitOverlay;
    private float ScoreLastFrame = 0;
    private float perSecond;
    private bool updatePerSec;
    private bool gamePaused;

    // Use this for initialization
    void Start () {
        world = GameObject.FindGameObjectWithTag("World");
        pauseOverlay.SetActive(false);
        resumeOverlay.SetActive(false);
        ExitOverlay.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (!gamePaused)
        {

            //score
            float Score = world.GetComponent<World>().players[0].GetComponent<Player>().money;
            if (gameTime % 5 > 3 && updatePerSec)
            {
                updatePerSec = false;
                perSecond = (Score - ScoreLastFrame) / Time.deltaTime;
            }
            else if (gameTime % 5 < 3)
            {
                updatePerSec = true;
            }

            if (perSecond >= 0)
                currency.text = "Money: " + Score.ToString("F0") + " +" + perSecond.ToString("F1");
            else
                currency.text = "Money: " + Score.ToString("F0") + " " + perSecond.ToString("F1");
            ScoreLastFrame = Score;

            //Game Timer
            gameTime = (int)Time.time;
            timeRender.text = (gameTime / 60).ToString("00") + ":" + (gameTime % 60).ToString("00");
        } else
        {
            
        }
    }

    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0;
        camera.GetComponent<cameraControls>().disabled = true;
        pauseOverlay.SetActive(true);
        resumeOverlay.SetActive(true);
        ExitOverlay.SetActive(true);
    }

    public void UnPauseGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
        camera.GetComponent<cameraControls>().disabled = false;
        pauseOverlay.SetActive(false);
        resumeOverlay.SetActive(false);
        ExitOverlay.SetActive(false);
    }

    public void Exit()
    {
        //Load the selected scene, by scene index number in build settings
        SceneManager.LoadScene(0);
    }
}
