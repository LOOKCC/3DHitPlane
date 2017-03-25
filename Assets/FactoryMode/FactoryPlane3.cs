﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FactoryPlane3 : FactoryP
{
    private FManager myManager;

    void Start()
    {
        InvokeRepeating("Create", 0f, 3f);
        myManager = GameObject.Find("FMManager").GetComponent<FManager>();
    }
    public override void Create()
    {
        if (myManager.gamestate == 0)
        {
            GameObject obj = ProductPlane3.current.GetProductInPool();
            obj.transform.position = new Vector3(100f, Random.Range(6f, 11f), Random.Range(-12f, 12f));
            obj.SetActive(true);
            Rigidbody r = obj.GetComponent<Rigidbody>();
            r.AddForce(-10, 0, 0, ForceMode.Impulse);
        }

    }
}