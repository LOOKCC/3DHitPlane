using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pool : MonoBehaviour {

    //public static benshen current;

    public int pooledAmount = 20;
    public bool willgrow = true;
    public GameObject bullet;
    public float firetiome = 0.5f;
    List<GameObject> bullets;

    void Awake()
    {
  //      current = this;
    }

	void Start () {
        bullets = new List<GameObject>();
        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            obj.SetActive(false);
            bullets.Add(obj);

           

        }

	}
    void fire()
    {

        for (int i = 0; i < bullets.Count; i++){
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = transform.position;
                bullets[i].transform.rotation = transform.rotation;
                bullets[i].SetActive(true);
                break;
            }
        }
    }
    public GameObject Getpoolgameobject()
    {
        for(int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }
        if (willgrow)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            bullets.Add(obj);
            return obj;
        }
        return null;
    }
}
