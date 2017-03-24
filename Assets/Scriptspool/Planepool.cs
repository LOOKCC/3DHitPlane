using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planepool : MonoBehaviour {

    public static Planepool current;
    public int PlaneAmount = 5;
    public GameObject Plane;
    public bool willGrow = true;
    public Stack<GameObject> Planes;
     
	void Awake()
    {
        current = this;
    }
	void Start () {
        Planes = new Stack<GameObject>();
        for(int i = 0; i < PlaneAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(Plane);    
            obj.SetActive(false);
            Planes.Push(obj);
        }
	
	}
    public GameObject GetPlaneInPool()
    {
        if(Planes.Count>0)
        {
            GameObject obj = Planes.Pop();
            if (!obj.activeInHierarchy)
            {
               
                return obj;
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(Plane);
            obj.SetActive(false);
            return obj;
        }
        
        return null;
    }
}
