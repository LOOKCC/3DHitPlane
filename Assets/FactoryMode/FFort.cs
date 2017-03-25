using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FFort : MonoBehaviour {

    private Transform fort_tran;
    private RaycastHit hit;
    private Ray ray;
    private Ray gun;
    private LineRenderer liner;

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

    void Start () {
        fort_tran = gameObject.GetComponent<Transform>();
        liner = gameObject.GetComponent<LineRenderer>();
        audiosplay = gameObject.GetComponent<AudioSource>();
        ShootAudio = audios[0];
        GetLowAudio = audios[1];
        GetBombAudio = audios[2];
        UseLowAudio = audios[3];
        UseBombAudio = audios[4];
    }
	
	
	void Update () {
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
                DestoryP De = hit.collider.gameObject.GetComponent<DestoryP>();
                De.MyDestroy();
            }
            if (hit.collider.gameObject.tag == "low")
            {
                lownumber++;
                audiosplay.PlayOneShot(GetLowAudio);
                lowtext.text = "FrozenLeft: " + lownumber;
                DestoryLB DeL = hit.collider.gameObject.GetComponent<DestoryLB>();
                DeL.DestroyL();
            }
            if (hit.collider.gameObject.tag == "bomb")
            {
                bombnumber++;
                audiosplay.PlayOneShot(GetBombAudio);
                bombtext.text = "BombLeft: " + bombnumber;
                DestoryLB DeB = hit.collider.gameObject.GetComponent<DestoryLB>();
                DeB.DestroyB();
            }
        }
    }
    void uselow()
    {
        if (Input.GetKeyDown(KeyCode.Q) && lownumber > 0)
        {
            lownumber--;
            lowtext.text = "FrozenLeft: " + lownumber;
            audiosplay.PlayOneShot(UseLowAudio);
        }
    }
    void usebomb()
    {
        if (Input.GetKeyDown(KeyCode.W) && bombnumber > 0)
        {
            bombnumber--;
            bombtext.text = "BombLeft: " + bombnumber;
            audiosplay.PlayOneShot(UseBombAudio);
        }
    }

}
