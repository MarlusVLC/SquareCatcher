using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private float _posX;
    private float _posY;
    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _text.text = "Score: " + GameManager.GetInstance.score;
        // _posX = -GameManager.GetInstance._camHeigth;
        // _posY = -GameManager.GetInstance._camWidth;
        //
        // transform.position = new Vector2(_posX, _posY);
    }
}
