using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class RecolorScript : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private GameObject rig;

    [SerializeField] private Slider slider_R;
    [SerializeField] private Slider slider_G;
    [SerializeField] private Slider slider_B;
    [SerializeField] private Image colorPreview;

    [SerializeField] private ParticleSystem partSys1;
    [SerializeField] private ParticleSystem partSys2;
    [SerializeField] private ParticleSystem partSys3;
    [SerializeField] private ParticleSystem partSys4;


    private void Start()
    {
        //GetAllComponents();
        ChangeColor();

        timeline.stopped += OnTimelineStopped;
        timeline.Play();
    }
    public void ChangeColor()
    {
        if(slider_R.value == 0 && slider_G.value == 0 && slider_B.value == 0)
        {
            Debug.Log("No color value has changed");
        }
        else
        {
            Color partSysColor = new Color(slider_R.value, slider_G.value, slider_B.value);
            colorPreview.color = partSysColor;


            //partSys1.colorOverLifetime.enabled = false;
            var colorOvrLifetime1 = partSys1.colorOverLifetime;
            var colorOvrLifetime2 = partSys1.colorOverLifetime;
            var colorOvrLifetime3 = partSys1.colorOverLifetime;
            var colorOvrLifetime4 = partSys1.colorOverLifetime;

            colorOvrLifetime1.enabled = false;
            colorOvrLifetime2.enabled = false;
            colorOvrLifetime3.enabled = false;
            colorOvrLifetime4.enabled = false;

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
            rig.transform.position = new Vector3(-6.63776809e-05f, 1.20140874f, 0.00292248302f);
            rig.transform.rotation = Quaternion.identity;  
            director.Play();


        }
    }
}
