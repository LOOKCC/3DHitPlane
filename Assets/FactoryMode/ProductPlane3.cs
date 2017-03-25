using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProductPlane3 : Product
{
    public GameObject Plane3;
    public static ProductPlane3 current;
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
            GameObject obj = (GameObject)Instantiate(Plane3);
         //   Rigidbody r = obj.GetComponent<Rigidbody>();
         //   r.AddForce(-10, 0, 0, ForceMode.Impulse);
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
            GameObject obj = (GameObject)Instantiate(Plane3);
            obj.SetActive(false);
            return obj;
        }
        return null;
    }
}