using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class RecolorScript : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private GameObject movingObj;
    [SerializeField] private GameObject rotatingObj;

    [SerializeField] private Slider slider_hue;
    [SerializeField] private Slider slider_saturation;
    [SerializeField] private Slider slider_TimeScale;
    [SerializeField] private Image colorPreview;

    [SerializeField] private ParticleSystem partSys1;
    [SerializeField] private ParticleSystem partSys2;
    [SerializeField] private ParticleSystem partSys3;
    [SerializeField] private ParticleSystem partSys4;


    private void Start()
    {
        //GetAllComponents();

        timeline.stopped += OnTimelineStopped;
        timeline.Play();
    }

    private void Update()
    {
        ChangeColor();
        rotatingObj.transform.rotation = Quaternion.identity;
    }
    public void ChangeColor()
    {
        if (slider_hue.value == 0 && slider_saturation.value == 0)
        {
            Debug.Log("No color value has changed");
        }
        else
        {
            Color hvsColor = new Color(slider_hue.value, slider_saturation.value, 1, 1);

            Color partSysColor = ColorExtensions.HSVToRGB(hvsColor);
            colorPreview.color = partSysColor;


            //partSys1.colorOverLifetime.enabled = false;
            DisableColorOverLifetime(partSys1);
            DisableColorOverLifetime(partSys2);
            DisableColorOverLifetime(partSys3);
            DisableColorOverLifetime(partSys4);

            var mainModule1 = partSys1.main;
            var mainModule2 = partSys2.main;
            var mainModule3 = partSys3.main;
            var mainModule4 = partSys4.main;

            mainModule1.startColor = partSysColor;
            mainModule2.startColor = partSysColor;
            mainModule3.startColor = partSysColor;
            mainModule4.startColor = partSysColor;
        }

    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        // Check if the director that stopped is the one we are monitoring
        if (director == timeline)
        {
            // Rewind and play again to create the loop
            director.time = 0;
            //movingObj.transform.position = Vector3.zero;
            director.Play();


        }
    }

    void DisableColorOverLifetime(ParticleSystem particle)
    {
        var colorOverLifetimeModule = particle.colorOverLifetime;
        colorOverLifetimeModule.enabled = false;
    }

    public void ChangeTimeScale()
    {
        Time.timeScale = slider_TimeScale.value;
    }

}

public static class ColorExtensions
{
    public static Color RGBToHSV(Color rgbColor)
    {
        Color.RGBToHSV(rgbColor, out float h, out float s, out float v);
        return new Color(h, s, v, rgbColor.a);
    }

    public static Color HSVToRGB(Color hsvColor)
    {
        return Color.HSVToRGB(hsvColor.r, hsvColor.g, hsvColor.b);
    }

}
