using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bombpool : MonoBehaviour {

    public static Bombpool current;
    public int BombAmount = 5;
    public GameObject Bomb;
    public bool willGrow = true;
    public Stack<GameObject> Bombs;

    void Awake()
    {
        current = this;
    }
    void Start()
    {
        Bombs = new Stack<GameObject>();
        for (int i = 0; i < BombAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(Bomb);
            obj.SetActive(false);
            Bombs.Push(obj);
        }

    }
    public GameObject GetBombInPool()
    {
        if (Bombs.Count > 0)
        {
            GameObject obj = Bombs.Pop();
            if (!obj.activeInHierarchy)
            {
                Debug.Log("bomb");
                return obj;
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(Bomb);
            obj.SetActive(false);
            return obj;
        }
       
        return null;
    }

}
