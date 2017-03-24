using UnityEngine;
using System.Collections;

public class DestoryLAB : MonoBehaviour {
  
    public void DestroyL()
    {
        if (gameObject.tag == "low")
        {
            gameObject.SetActive(false);
            Lowpool.current.Lows.Push(gameObject);
        }
    }
    public void DestroyB() {
        if (gameObject.tag == "bomb")
        {
            gameObject.SetActive(false);
            Bombpool.current.Bombs.Push(gameObject);
        }
    }

}
