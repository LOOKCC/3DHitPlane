using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Createpool : MonoBehaviour {

    private Managerpool myManager;

    public Text time;
    private float alltime;
    private float nowtime;

    void Start () {
        myManager = GameObject.Find("Manager").GetComponent<Managerpool>();
        InvokeRepeating("CreatePlane", 0f, 1f);
        InvokeRepeating("CreatePlane3", 0f, 3f);
        InvokeRepeating("CreateBombPlane", 0f, 3f);
        InvokeRepeating("CreateLow", 5f, Random.Range(10f, 15f));
        InvokeRepeating("CreateBomb", 5f, Random.Range(10f, 15f));
        alltime = 40 + Time.time;
    }
	void CreatePlane()
    {
        if(myManager.gamestate == 0)
        {
            GameObject obj = Planepool.current.GetPlaneInPool();
            obj.transform.position = new Vector3(100f, Random.Range(6f, 11f), Random.Range(-12f, 12f));
            obj.SetActive(true);
            Rigidbody r = obj.GetComponent<Rigidbody>();
            r.AddForce(-5, 0, 0, ForceMode.Impulse);
        }
        
    }
    void CreatePlane3()
    {
        if (myManager.gamestate == 0)
        {
            GameObject obj = Plane3pool.current.GetPlane3InPool();
            obj.transform.position = new Vector3(100f, Random.Range(6f, 11f), Random.Range(-12f, 12f));
            obj.SetActive(true);
            Rigidbody r = obj.GetComponent<Rigidbody>();
            r.AddForce(-10, 0, 0, ForceMode.Impulse);
        }
       
    }
    void CreateBombPlane()
    {
        if (myManager.gamestate == 0)
        {
            GameObject obj = BombPlanepool.current.GetBombPlaneInPool();
            obj.transform.position = new Vector3(100f, Random.Range(6f, 11f), Random.Range(-12f, 12f));
            obj.SetActive(true);
            Rigidbody r = obj.GetComponent<Rigidbody>();
            r.AddForce(-5, 0, 0, ForceMode.Impulse);
        }
        
    }
    void CreateBomb()
    {
        if (myManager.gamestate == 0)
        {
            GameObject obj = Bombpool.current.GetBombInPool();
            obj.transform.position = new Vector3(4f, 1f, -4f);
            obj.SetActive(true);
        }
        
    }
    void CreateLow()
    {
        if (myManager.gamestate == 0)
        {
            GameObject obj = Lowpool.current.GetLowInPool();
            obj.transform.position = new Vector3(4f, 1f, 4f);
            obj.SetActive(true);
        }
    }

    void Update () {
        ShowTime();
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
            myManager.gamestate = 1;
        }
    }
}
