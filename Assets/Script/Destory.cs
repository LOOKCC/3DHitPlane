using UnityEngine;
using  UnityEngine.UI;
using System.Collections;

public class Destory : MonoBehaviour {

    private Transform m_Transform;
    private Manager myManager;
    private Rigidbody myRigidbody;

   

    void Start()
    {
        myManager = GameObject.Find("Main Camera").GetComponent<Manager>();
        m_Transform = gameObject.GetComponent<Transform>();
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

	void Update () {
        loser();
        examstare();  
	}
    void loser()
    {
        if (m_Transform.position.x < -10)
        {
            Destroy(gameObject);
            myManager.gamestate = 4;
        }
    }
    void examstare()
    {
        /*     if (myManager.gamestate == 2)
             {
                 Destroy(gameObject);
                 Debug.Log("boom");
             }
             if (myManager.gamestate == 1)
             {
                 beganlow();
                 StartCoroutine(waitlow());
                 endlow();
                 Debug.Log("low");
             }
             */
        if (Input.GetKeyDown(KeyCode.W))
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(myRigidbody);
        }
        if (myManager.gamestate == 0)
        {
            //do nothing
        }
        if (myManager.gamestate == 3|| myManager.gamestate == 4)
        {
            Destroy(gameObject);
        }
        
    }
    public void beganlow()
    {
        myRigidbody.AddForce(15, 0, 0, ForceMode.Impulse);
    }
    public void endlow()
    {
        myRigidbody.AddForce(-15, 0, 0, ForceMode.Impulse);
    }
    IEnumerator waitlow()
    {
        yield return new WaitForSeconds(3);
    }
    

}
