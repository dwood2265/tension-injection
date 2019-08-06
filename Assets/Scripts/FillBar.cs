using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    public Slider mySlider;
    public Player myPlayer;


private float currentValue = 0f;
public float CurrentValue {
    get {
        return currentValue;
    }
    set {
        currentValue = value;
        mySlider.value = currentValue;
    }
}
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
