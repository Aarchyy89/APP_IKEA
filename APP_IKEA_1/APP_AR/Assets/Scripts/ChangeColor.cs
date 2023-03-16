using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Color Color;
    [SerializeField] private Image Img;
    [SerializeField] private Image Img2;
    [SerializeField] private Image Img3;

    private int colorValue;
    
    // Start is called before the first frame update
    void Start()
    {
        Color.a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewColor()
    {
        Img.color = Color;
    }
}
