using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Timers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera maincamera;
    [SerializeField] public float genPosY;
    [SerializeField] public GameObject[] geoForms;
    [SerializeField] float genTimeMin;
    [SerializeField] float genTimeMax;

    public ArrayList _catchedObjects;
    
    private float genTime;
    private float timer = 0f;
    private float genPosX;
    
    public float _camWidth;
    public float _camHeigth;

    
    public float score = 2;
    private int _multiplier;




    private static GameManager INSTANCE;

    public static GameManager GetInstance
    {
        get { return INSTANCE; }
    }
    void Awake()
    {
        //SINGLETON begin
        if (INSTANCE != null && INSTANCE != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            INSTANCE = this;
        }



        genTime = (genTimeMax + genTimeMin) / 2;

        _catchedObjects = new ArrayList();
    }

    void Start()
    {
        _camHeigth = maincamera.orthographicSize;
        _camWidth = _camHeigth * Screen.width / Screen.height;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= genTime)
        {
            int geoForm = Random.Range(0, geoForms.GetLength(0)-1);
            GameObject form = (GameObject) geoForms.GetValue(geoForm);
            genPosX = Random.Range(-_camWidth + 1, _camWidth - 1);
            Instantiate(form, new Vector2(genPosX, genPosY), Quaternion.identity);
            timer = 0;
            genTime = Random.Range(genTimeMin, genTimeMax);
        }
        
        DestroyCatched();
    }

    void DestroyCatched()
    {
        
        _multiplier = (int)_catchedObjects.Count / 2;
        _multiplier = _multiplier == 0 ? 1 : _multiplier;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            int currScore = 0;
            foreach (GameObject square in _catchedObjects)
            {
                Destroy(square);
                currScore++;

            }

            currScore *= _multiplier;
            score += currScore;
        }
    }
}
