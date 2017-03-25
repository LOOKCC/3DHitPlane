using UnityEngine;
using System.Collections;

public class DestoryLB : MonoBehaviour {

    public void DestroyL()
    {
        if (gameObject.tag == "low")
        {
            gameObject.SetActive(false);
            ProductLow.current.Products.Push(gameObject);
        }
    }
    public void DestroyB()
    {
        if (gameObject.tag == "bomb")
        {
            gameObject.SetActive(false);
            Productbomb.current.Products.Push(gameObject);
        }
    }

}
