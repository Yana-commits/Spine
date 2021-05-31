using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class HUD : MonoBehaviour
{
    public Joystick joystick;

    public Button shootbutton;

    public Button bowbutton;

    public JoyButton joyBowButton;

    public Slider mySlider;

    public Button pauseBtn;

    public Action<JoyButton> OnBow;

    private void Start()
    {
        bowbutton.onClick.AddListener(() => OnBow?.Invoke(joyBowButton));
    }
    private void OnDestroy()
    {
        bowbutton.onClick.RemoveListener(() => OnBow?.Invoke(joyBowButton));
    }

    public event UnityAction OnPause
    {
        add => pauseBtn.onClick.AddListener(value);
        remove => pauseBtn.onClick.RemoveListener(value);
    }
    public event UnityAction OnShoot
    {
        add => shootbutton.onClick.AddListener(value);
        remove => shootbutton.onClick.RemoveListener(value);
    }
   
  
}
