using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour {


    public Text lose;
    public Text win;
    //  public enum GameState { Gameing, GameLow, GameOver };
    public int gamestate;
    // gamestate=0 means gameing
    // gamestste=1 means low
    // gamestate=2 means bomb
    // gamestate=3 means win
    // gamestste=4 means lose
    void Start()
    {
        win.text = "";
        lose.text = "";
        gamestate = 0;
    }


    void Update()
    {
        if (gamestate == 3)
        {
            win.text = "WIN";
            // play winaudio
        }
        if (gamestate == 4)
        {
            lose.text = "LOSE";
            //play loseaudio
        }

    }
}
