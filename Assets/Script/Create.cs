using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Create : MonoBehaviour {

    private Manager myManager; 

    public GameObject plane;
    public GameObject plane3;
    public GameObject bombplane;
    public GameObject low;
    public GameObject bomb;

    private Rigidbody planerb;
    private Rigidbody plane3rb;
    private Rigidbody bombplanerb;

    public Text time;
    private float alltime;
    private float nowtime;

    void Start () {
        myManager = GameObject.Find("Main Camera").GetComponent<Manager>();
        InvokeRepeating("createplane", 0f, 1f);
        InvokeRepeating("createplane3", 0f, 3f);
        InvokeRepeating("createbombplane", 0f, 3f);
        InvokeRepeating("createlow", 5f, Random.Range(10f,15f));
        InvokeRepeating("createbomb", 5f, Random.Range(10f, 15f));
        alltime = 40 + Time.time;
    }
	
	
	void Update () {
        showtime();
    }
    void createplane()
    {
            GameObject goplane = Instantiate(plane, new Vector3(100f, Random.Range(6f,11f), Random.Range(-12f,12f)), Quaternion.Euler(0f,-90f,0f)) as GameObject;
            planerb = goplane.GetComponent<Rigidbody>();
            planerb.AddForce(-15, 0, 0, ForceMode.Impulse);
    }
    void createplane3()
    {
        GameObject goplane3 = Instantiate(bombplane, new Vector3(100f, Random.Range(6f, 11f), Random.Range(-12f, 12f)), Quaternion.Euler(-90f, -90f, -90f)) as GameObject;
        plane3rb = goplane3.GetComponent<Rigidbody>();
        plane3rb.AddForce(-45, 0, 0, ForceMode.Impulse);
    }
    void createbombplane()
    {
        GameObject gobombplane = Instantiate(plane3, new Vector3(100f, Random.Range(6f, 11f), Random.Range(-12f, 12f)), Quaternion.Euler(-90f, 0f, 180f)) as GameObject;
        bombplanerb = gobombplane.GetComponent<Rigidbody>();
        bombplanerb.AddForce(-20, 0, 0, ForceMode.Impulse);
    }
    void createlow()
    {
        Instantiate(low, new Vector3(4f, 1f, 4f), Quaternion.identity);
    }
    void createbomb()
    {
        Instantiate(bomb, new Vector3(4f, 1f, -4f), Quaternion.identity);
    }
    void showtime()
    {
        nowtime = alltime - Time.time;
        if (nowtime > 0)
        {
            time.text = "Time: " + nowtime;
            myManager.gamestate = 0;
        }

        if (nowtime <= 0)
        {
            time.text = "Time: 0";
            myManager.gamestate = 3;
        }
    }
}
