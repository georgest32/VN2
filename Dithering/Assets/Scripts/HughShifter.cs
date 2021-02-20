using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HughShifter : MonoBehaviour
{
    //remember to drag and drop your scriptable object into this field in the inspector...
    public PostProcessProfile ppProfile;
    public float hueChangeValue;
    public float lensChangeValue;
    private bool lensCycleUp = false;

    private void Start()
    {
        ppProfile.GetSetting<ColorGrading>().colorFilter.value.a = 0;
        ppProfile.GetSetting<LensDistortion>().intensity.value = -22;
    }

    void Update()
    {
        if (GetComponent<PostProcessVolume>().profile.name == "AmpProfile")
        {
            ChangeChromAberHue(hueChangeValue);
            ChangeLensDistortionIntensity(lensChangeValue);
            ChangeColorFilter(hueChangeValue / 100);
        }
    }

    void ChangeChromAberHue(float val)
    {
        //copy current "depth of field" settings from the profile into a temporary variable
        FloatParameter hueSetting = ppProfile.GetSetting<ColorGrading>().hueShift;
        hueSetting.value += Time.deltaTime * val;
        //set the "depth of field" settings in the actual profile to the temp settings with the changed value
        ppProfile.GetSetting<ColorGrading>().hueShift = hueSetting;
    }

    void ChangeLensDistortionIntensity(float val)
    {
        FloatParameter intensitySetting = ppProfile.GetSetting<LensDistortion>().intensity;
        float intensity = intensitySetting.value;

        if (lensCycleUp)
        {
            if (intensity > 0)
            {
                //Mathf.Lerp(-22, 0);
                lensCycleUp = false;
            }
            intensitySetting.value += val * Time.deltaTime;
        }
        else
        {
            if (intensity < -22)
            {
                lensCycleUp = true;
            }
            intensitySetting.value -= val * Time.deltaTime;
        }

        ppProfile.GetSetting<LensDistortion>().intensity = intensitySetting;

    }

    void ChangeColorFilter(float val)
    {
        //copy current "depth of field" settings from the profile into a temporary variable
        ColorParameter filterColorSetting = ppProfile.GetSetting<ColorGrading>().colorFilter;
        filterColorSetting.value.a += Time.deltaTime * val;
        //set the "depth of field" settings in the actual profile to the temp settings with the changed value
        ppProfile.GetSetting<ColorGrading>().colorFilter = filterColorSetting;
    }
}
