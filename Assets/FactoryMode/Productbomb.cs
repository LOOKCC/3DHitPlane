using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Productbomb : Product
{
    public GameObject bomb;
    public static Productbomb current;
    public Stack<GameObject> Products;

    void Awake()
    {
        current = this;
    }
    void Start()
    {
        Products = new Stack<GameObject>();
        for (int i = 0; i < ProductAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(bomb);
            obj.SetActive(false);
            Products.Push(obj);
        }
    }
    public GameObject GetProductInPool()
    {
        if (Products.Count > 0)
        {
            GameObject obj = Products.Pop();
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(bomb);
            obj.SetActive(false);
            return obj;
        }
        return null;
    }
}
