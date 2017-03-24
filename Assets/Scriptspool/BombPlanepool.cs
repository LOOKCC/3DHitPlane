using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombPlanepool : MonoBehaviour {
    public static BombPlanepool current;
    public int BombPlaneAmount = 5;
    public GameObject BombPlane;
    public bool willGrow = true;
    public Stack<GameObject> BombPlanes;

    void Awake()
    {
        current = this;
    }
    void Start()
    {
        BombPlanes = new Stack<GameObject>();
        for (int i = 0; i < BombPlaneAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(BombPlane);
            obj.SetActive(false);
            BombPlanes.Push(obj);
        }

    }
    public GameObject GetBombPlaneInPool()
    {
        if ( BombPlanes.Count>0)
        {
            
            GameObject obj = BombPlanes.Pop();
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(BombPlane);
            obj.SetActive(false);
            
            return obj;
        }
       
        return null;
    }
}
