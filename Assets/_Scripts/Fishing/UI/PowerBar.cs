using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private Image fillArea;
    [SerializeField] private List<Color> _colors;
    [SerializeField] private List<float> thresholds;
    
    private Slider powerBar;
    private bool isBiteThrown;
    private bool isIncreasing = true;
    void Start()
    {
        powerBar = GetComponent<Slider>();
        OnStartFishing();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    void OnStartFishing()
    {
        float sinAngle = 0;
        DOTween.To(() => sinAngle, x => sinAngle = x, Mathf.PI, sensitivity)
            .OnUpdate(()=> 
            {
                powerBar.value = Mathf.Sin(sinAngle);
                InterpolateSlider(powerBar.value);
            })
            .OnComplete(OnStartFishing);
    }

    private void InterpolateSlider(float powerValue)
    {
        if (powerValue < thresholds[0] && powerValue>=0)
        {
            float t = powerValue / thresholds[0];
            fillArea.color = Color.Lerp(_colors[0], _colors[1], t);
        }
        else if(powerValue >= thresholds[0] && powerValue < thresholds[1])
        {
            float t = powerValue/1;
            fillArea.color = Color.Lerp(_colors[1], _colors[2], t);
        }
        else
        {
            fillArea.color = _colors[2];
        }
    }
}
