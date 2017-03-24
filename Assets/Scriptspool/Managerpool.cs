using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Managerpool : MonoBehaviour {

    public Text lose;
    public Text win;
    public int gamestate;
    void Start () {
        win.text = "";
        lose.text = "";
        gamestate = 0;

    }
	
	
	void Update () {
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
}
