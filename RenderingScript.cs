using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Boxophobic;

public class RenderingScript : MonoBehaviour
{
    public Animator sunAnimator;
    public float speed;
    //TIME PROPERTIES
    public float minute, time_scale;
    public int hour;
    public Text minute_text, hour_text;
    //FOR SKYBOX AND LIGHTNING//
    [SerializeField]
    float exposure_sky, rotation_sky_speed;
    [SerializeField]
    Color Atmosphere_color;
    [SerializeField]
    [Range(0f, 0.8f)]
    float[] sky_c;
    [SerializeField]
    [Range(0f, 0.05f)]
    float[] render_property;
    [SerializeField]
    Light DirectionLight;
    //WEATHER PROPERTIES//
    [SerializeField]
    int weatherRandomizer;
    [SerializeField]
    WindZone mainWindZone;
    [SerializeField]
    float wind_main, wind_turbulence, wind_pulse_magnitude, wind_pulse_frequency;
    


    public void Start()
    {
        rotation_sky_speed = UnityEngine.Random.Range(1.5f, 2f);
        DirectionLight = GetComponent<Light>();
        hour = UnityEngine.Random.Range(12,14);
        minute = UnityEngine.Random.Range(0, 60);
        time_scale = 1f;
        sunAnimator.speed = 0.01f;
        //GET WEATHER ON START//
        mainWindZone = GameObject.FindGameObjectWithTag("main_wind").GetComponent<WindZone>();
        wind_main = 1.25f;
        wind_turbulence = 1.25f;
        wind_pulse_magnitude = 1.2f;
        wind_pulse_frequency = 0.75f;
        ///SET WEATHER ON START//
        ///
     







    }


    public void Update()
    {
        
        //SET SKYBOX//
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotation_sky_speed);
        RenderSettings.skybox.SetFloat("_Exposure", exposure_sky);
        Atmosphere_color = new Color(sky_c[0], sky_c[1], sky_c[2]);
        DirectionLight.color = Atmosphere_color;
        RenderSettings.skybox.SetColor("_Tint", Atmosphere_color);



        ////
        ///TIME PROPERTIES
        ///
        Time.timeScale = time_scale;
        hour_text.text = hour.ToString() + "H: ";
        minute_text.text = minute.ToString("F0");
        minute += 0.01f * Time.timeScale;
        if (minute >= 60)
        {
            hour += 1;
            minute = 0;
        }

        
        ///WEATHER PROPERTIES///
        ///
        RenderSettings.fogColor = Atmosphere_color;
        RenderSettings.fogDensity = render_property[0];
        weatherRandomizer = UnityEngine.Random.Range(1, 50000);
        mainWindZone.windMain = wind_main;
        mainWindZone.windTurbulence = wind_turbulence;
        mainWindZone.windPulseMagnitude = wind_pulse_magnitude;
        mainWindZone.windPulseFrequency = wind_pulse_frequency;
        if (weatherRandomizer == 1000)
        {
            
            wind_main = 1.9f;
            wind_turbulence = 1.25f;
            wind_pulse_magnitude = 1.25f;
            wind_pulse_frequency = 1f;
        }
        else if (weatherRandomizer == 20000)
        {
           
            wind_main = 1.7f;
            wind_turbulence = 1.5f;
            wind_pulse_magnitude = 1.5f;
            wind_pulse_frequency = 1.2f;
        }
        else if(weatherRandomizer == 40000)
        {
           
            wind_main = 1.6f;
            wind_turbulence = 1.3f;
            wind_pulse_magnitude = 1.5f;
            wind_pulse_frequency = 0.95f;
        }


    }



    /// <summary>
    /// FOR ANIMATOR
    /// </summary>
    
}
