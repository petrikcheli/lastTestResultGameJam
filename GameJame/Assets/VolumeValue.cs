using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    private AudioSource audioSource;
    private float volume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volume;
    }
    public void SetVolume(float volume)
    {
        this.volume = volume;
    }
}
/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    private SpriteRenderer spriteRender;
    Renderer rend;
    float value1, value2;
    Transform slider;

    private void Start()
    {
        slider = GetComponent<Transform>();
        value1 =
        spriteRender = GetComponent<SpriteRenderer>();
        if (spriteRender == null)
        {
            spriteRender.sprite = sprite1;
        }
    }

    public void ChangeMisc()
    {
        if (value1 == 0)
        {
            spriteRender.sprite = sprite2;
        }
        else
        {
            spriteRender.sprite = sprite1;
        }
    }

    public void ChangeSound()
    {
        if (value2 == 0)
        {
            spriteRender.sprite = sprite3;
        }
        else
        {
            spriteRender.sprite = sprite1;
        }
    }

    private void Update()
    {

    }
}
*/