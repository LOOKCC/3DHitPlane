﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fort : MonoBehaviour
{
    private Transform fort_tran;
    private RaycastHit hit;
    private Ray ray;
    private Ray gun;
    private LineRenderer liner;

    private Manager myManager;

    private AudioSource audiosplay;
    public AudioClip[] audios = new AudioClip[5];
    private AudioClip ShootAudio;
    private AudioClip GetLowAudio;
    private AudioClip GetBombAudio;
    private AudioClip UseLowAudio;
    private AudioClip UseBombAudio;


    public Text lowtext;
    public Text bombtext;
    private float lownumber = 0;
    private float bombnumber = 0;

    void Start()
    {
        myManager = GameObject.Find("Main Camera").GetComponent<Manager>();
        fort_tran = gameObject.GetComponent<Transform>();
        liner = gameObject.GetComponent<LineRenderer>();
        audiosplay = gameObject.GetComponent<AudioSource>();
        ShootAudio = audios[0];
        GetLowAudio = audios[1];
        GetBombAudio = audios[2];
        UseLowAudio = audios[3];
        UseBombAudio = audios[4];
    }

    void Update()
    {
        shoot();
        usebomb();
        uselow();
    }
    void shoot()
    {
        liner.SetPosition(0, fort_tran.position);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        liner.SetPosition(1, ray.direction * 1000 - fort_tran.position);
        gun = new Ray(fort_tran.position, ray.direction * 1000 - fort_tran.position);
        if (Physics.Raycast(gun, out hit))
        {
            if (hit.collider.gameObject.tag == "plane" || hit.collider.gameObject.tag == "3plane" || hit.collider.gameObject.tag == "bombplane")
            {
                audiosplay.PlayOneShot(ShootAudio);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.gameObject.tag == "low")
            {
                lownumber++;
                audiosplay.PlayOneShot(GetLowAudio);
                lowtext.text = "FrozenLeft: " + lownumber;
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.gameObject.tag == "bomb")
            {
                bombnumber++;
                audiosplay.PlayOneShot(GetBombAudio);
                bombtext.text = "BombLeft: " + bombnumber;
                Destroy(hit.collider.gameObject);
            }
        }
    }
    void uselow()
    {
        if (Input.GetKeyDown(KeyCode.Q) && lownumber > 0)
        {
            myManager.gamestate = 1;
            lownumber--;
            lowtext.text = "FrozenLeft: " + lownumber;
            audiosplay.PlayOneShot(UseLowAudio);
            StartCoroutine(waitlow());
            myManager.gamestate = 0;
        }
    }
    void usebomb()
    {
        if (Input.GetKeyDown(KeyCode.W) && bombnumber > 0)
        {
            myManager.gamestate = 2;
            bombnumber--;
            bombtext.text = "BombLeft: " + bombnumber;
            audiosplay.PlayOneShot(UseBombAudio);
          //  StartCoroutine(waitbomb());
            myManager.gamestate = 0;
        }
    }
    IEnumerator waitlow()
    {
        yield return new WaitForSeconds(3);
    }
    IEnumerator waitbomb()
    {
        yield return new WaitForSeconds(0.5f);
    }
}

