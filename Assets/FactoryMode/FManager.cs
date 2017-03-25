using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FManager : MonoBehaviour {

    public Text lose;
    public Text win;
    public int gamestate;

    public Text time;
    private float alltime;
    private float nowtime;

    void Start () {
        win.text = "";
        lose.text = "";
        gamestate = 0;
        alltime = 40 + Time.time;

    }

	void Update () {
        ShowTime();
        if (gamestate == 1)
        {
            win.text = "WIN";
            // play winaudio
        }
        if (gamestate == 2)
        {
            lose.text = "LOSE";
            //play loseaudio
        }
    }
    void ShowTime()
    {
        nowtime = alltime - Time.time;
        if (nowtime > 0)
        {
            time.text = "Time: " + nowtime;
        }

        if (nowtime <= 0)
        {
            time.text = "Time: 0";
            gamestate = 1;
        }
    }
}
