using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FactoryBomb : FactoryLB
{
    private FManager myManager;
    void Start()
    {
        InvokeRepeating("Create", 5f, Random.Range(10f, 15f));
        myManager = GameObject.Find("FMManager").GetComponent<FManager>();
    }

    public override void Create()
    {
        if (myManager.gamestate == 0)
        {
            GameObject obj = Productbomb.current.GetProductInPool();
            obj.transform.position = new Vector3(4f, 1f, -4f);
            obj.SetActive(true);
        }
    }
}