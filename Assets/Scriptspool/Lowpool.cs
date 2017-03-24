using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lowpool : MonoBehaviour {

    public static Lowpool current;
    public int LowAmount = 5;
    public GameObject Low;
    public bool willGrow = true;
    public Stack<GameObject> Lows;

    void Awake()
    {
        current = this;
    }
    void Start()
    {
        Lows = new Stack<GameObject>();
        for (int i = 0; i < LowAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(Low);
            obj.SetActive(false);
            Lows.Push(obj);
        }

    }
    public GameObject GetLowInPool()
    {
        if (Lows.Count > 0)
        {
            GameObject obj = Lows.Pop();
            if (!obj.activeInHierarchy)
            {
             
                return obj;
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(Low);
            obj.SetActive(false);
            return obj;
        }
        
        return null;
    }
}
