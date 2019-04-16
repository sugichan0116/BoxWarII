using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeBehaviour : MonoBehaviour
{
    public Text label;
    public Slider slider;
    [SerializeField]
    private string title;
    [SerializeField]
    private float rate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        label.text = title;
        slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, rate);
    }

    public void Title(string value) => title = value;
    public void Rate(float value) => rate = value;
}
