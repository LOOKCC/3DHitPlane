using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Plane3pool : MonoBehaviour {

    public static Plane3pool current;
    public GameObject Plane3;
    public int Plane3Amount = 5;
    public bool WillGrow = true;
    public Stack<GameObject> Plane3s;

    void Awake()
    {
        current = this;
    }
    void Start()
    {
        Plane3s = new Stack<GameObject>();
        for(int i = 0; i < Plane3Amount; i++)
        {
            GameObject obj = (GameObject)Instantiate(Plane3);
            obj.SetActive(false);
            Plane3s.Push(obj);
        }
    }
    public GameObject GetPlane3InPool()
    {
        if ( Plane3s.Count>0)
        {
            GameObject obj = Plane3s.Pop();
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        if (WillGrow)
        {
            GameObject obj = (GameObject)Instantiate(Plane3);
            obj.SetActive(false);
            return obj;
        }
        
        return null;
    }
    
}
