using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecolorScript : MonoBehaviour
{

    [SerializeField] private Slider slider_R;
    [SerializeField] private Slider slider_G;
    [SerializeField] private Slider slider_B;

    [SerializeField] private ParticleSystem partSys1;
    [SerializeField] private ParticleSystem partSys2;
    [SerializeField] private ParticleSystem partSys3;
    [SerializeField] private ParticleSystem partSys4;


    private void Start()
    {
        ChangeColor();
    }
    public void ChangeColor()
    {
        if(slider_R.value == 0 && slider_G.value == 0 && slider_B.value == 0)
        {
            return;
        }
        else
        {
            Color partSysColor = new Color(slider_R.value, slider_G.value, slider_B.value);

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

}
