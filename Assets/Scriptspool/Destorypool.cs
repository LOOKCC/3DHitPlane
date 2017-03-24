using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Destorypool : MonoBehaviour {

    private Transform m_Transform;
    private Managerpool myManager;
    private Rigidbody myRigidbody;

    void Start () {
        myManager = GameObject.Find("Manager").GetComponent<Managerpool>();
        m_Transform = gameObject.GetComponent<Transform>();
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }
	
	
	void Update () {
        Looser();
        CheckState();
	}
    void Looser()
    {
        if (m_Transform.position.x < -10)
         {
            MyDestroy();
            myManager.gamestate = 2;
         }
    }
    public void MyDestroy()
    {
        gameObject.SetActive(false);
        if (gameObject.tag == "plane")
        {
            if (!gameObject.GetComponent<Rigidbody>())
            {
                gameObject.AddComponent<Rigidbody>();
                Rigidbody r = gameObject.GetComponent<Rigidbody>();
                r.useGravity = false;
            }
            Planepool.current.Planes.Push(gameObject);
        }
        if (gameObject.tag == "plane3")
        {
            if (!gameObject.GetComponent<Rigidbody>())
            {
                gameObject.AddComponent<Rigidbody>();
                Rigidbody r = gameObject.GetComponent<Rigidbody>();
                r.useGravity = false;
            }
            Plane3pool.current.Plane3s.Push(gameObject);
           
        }
        if (gameObject.tag == "bombplane")
        {
            if (!gameObject.GetComponent<Rigidbody>())
            {
                gameObject.AddComponent<Rigidbody>();
                Rigidbody r = gameObject.GetComponent<Rigidbody>();
                r.useGravity = false;
            }
            BombPlanepool.current.BombPlanes.Push(gameObject);
           
        }
    }
    void CheckState()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (gameObject.activeInHierarchy)
            {
                MyDestroy();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (gameObject.activeInHierarchy)
            {
                Destroy(myRigidbody);
            }
        }
        if (myManager.gamestate == 1 || myManager.gamestate == 2)
        {
            MyDestroy();
        }
    }
}
