using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Audio_controller : MonoBehaviour
{
    [SerializeField] private AudioMixer m_AudioMixer;
    [SerializeField] private Slider m_MusicMasterSlider;
    [SerializeField] private Slider m_MusicBGMSlider;
    [SerializeField] private Slider m_MusicSFXSlider;
    [SerializeField] private Slider m_MusicSkill_VoiceSlider;

    [SerializeField] private Button BGM_switch;
    [SerializeField] private Button SFX_switch;
    [SerializeField] private Button Skill_voice_switch;


    private bool BGM_Muted = true; // ���Ұ� ���¸� ��Ÿ���� ����
    private bool SFX_Muted = true;
    private bool Skill_Voice_Muted = true;

    private void Awake()
    {
        //m_MusicMasterSlider.onValueChanged.AddListener(SetMasterVolume);
        m_MusicBGMSlider.onValueChanged.AddListener(SetBGMVolume);
        m_MusicSFXSlider.onValueChanged.AddListener(SetSFXVolume);
        m_MusicSkill_VoiceSlider.onValueChanged.AddListener(SetSkill_VoiceVolume);
    }

    void Update()
    {
        if (m_MusicBGMSlider.value > 0.001f)
        {
            if (BGM_switch != null)
            {
                Color color1 = BGM_switch.GetComponent<Image>().color;
                Text text1 = BGM_switch.GetComponentInChildren<Text>();
                Color color4 = BGM_switch.GetComponentInChildren<Text>().color;
                if (text1 != null)
                {
                    color4.r = 68 / 255f;
                    color4.g = 41 / 255f;
                    color4.b = 11 / 255f;
                    BGM_switch.GetComponentInChildren<Text>().color = color4;
                    text1.text = "on";
                }
                color1.a = 1f;
                BGM_switch.GetComponent<Image>().color = color1;
                BGM_Muted = true;
            }
        }
        if (m_MusicSFXSlider.value > 0.001f)
        {
            if (SFX_switch != null)
            {
                Color color2 = SFX_switch.GetComponent<Image>().color;
                Text text2 = SFX_switch.GetComponentInChildren<Text>();
                Color color5 = SFX_switch.GetComponentInChildren<Text>().color;
                if (text2 != null)
                {
                    color5.r = 68 / 255f;
                    color5.g = 41 / 255f;
                    color5.b = 11 / 255f;
                    SFX_switch.GetComponentInChildren<Text>().color = color5;
                    text2.text = "on";
                }
                color2.a = 1f;
                SFX_switch.GetComponent<Image>().color = color2;
                SFX_Muted = true;
            }
        }
        if (m_MusicSkill_VoiceSlider.value > 0.001f)
        {
            if (Skill_voice_switch != null)
            {
                Color color3 = Skill_voice_switch.GetComponent<Image>().color;
                Text text3 = Skill_voice_switch.GetComponentInChildren<Text>();
                Color color6 = Skill_voice_switch.GetComponentInChildren<Text>().color;
                if (text3 != null)
                {
                    color6.r = 68 / 255f;
                    color6.g = 41 / 255f;
                    color6.b = 11 / 255f;
                    Skill_voice_switch.GetComponentInChildren<Text>().color = color6;
                    text3.text = "on";
                }
                color3.a = 1f;
                Skill_voice_switch.GetComponent<Image>().color = color3;
                Skill_Voice_Muted = true;
            }
        }

        if (m_MusicBGMSlider.value <= 0.001f)
        {
            if (BGM_switch != null)
            {
                Color color1 = BGM_switch.GetComponent<Image>().color;
                Text text1 = BGM_switch.GetComponentInChildren<Text>();
                Color color7 = BGM_switch.GetComponentInChildren<Text>().color;
                if (text1 != null)
                {
                    color7.r = 255 / 255f;
                    color7.g = 255 / 255f;
                    color7.b = 255 / 255f;
                    BGM_switch.GetComponentInChildren<Text>().color = color7;
                    text1.text = "off";
                }
                color1.a = 0f;
                BGM_switch.GetComponent<Image>().color = color1;
                BGM_Muted = false;
            }
        }
        if (m_MusicSFXSlider.value <= 0.001f)
        {
            if (SFX_switch != null)
            {
                Color color2 = SFX_switch.GetComponent<Image>().color;
                Text text2 = SFX_switch.GetComponentInChildren<Text>();
                Color color8 = SFX_switch.GetComponentInChildren<Text>().color;
                if (text2 != null)
                {
                    color8.r = 255 / 255f;
                    color8.g = 255 / 255f;
                    color8.b = 255 / 255f;
                    SFX_switch.GetComponentInChildren<Text>().color = color8;
                    text2.text = "off";
                }
                color2.a = 0f;
                SFX_switch.GetComponent<Image>().color = color2;
                SFX_Muted = false;
            }
        }
        if (m_MusicSkill_VoiceSlider.value <= 0.001f)
        {
            if (Skill_voice_switch != null)
            {
                Color color3 = Skill_voice_switch.GetComponent<Image>().color;
                Text text3 = Skill_voice_switch.GetComponentInChildren<Text>();
                Color color9 = Skill_voice_switch.GetComponentInChildren<Text>().color;
                if (text3 != null)
                {
                    color9.r = 255 / 255f;
                    color9.g = 255 / 255f;
                    color9.b = 255 / 255f;
                    Skill_voice_switch.GetComponentInChildren<Text>().color = color9;
                    text3.text = "off";
                }
                color3.a = 0f;
                Skill_voice_switch.GetComponent<Image>().color = color3;
                Skill_Voice_Muted = false;
            }
        }
    }

    public void SetMasterVolume(float volume)
    {
        m_AudioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }

    public void SetBGMVolume(float volume)
    {
        m_AudioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        m_AudioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void SetSkill_VoiceVolume(float volume)
    {
        m_AudioMixer.SetFloat("Skill_Voice", Mathf.Log10(volume) * 20);
    }


    public void Toggle_BGM_Mute()
    {
        // ���� ���Ұ� ���¿� ���� ���� ����
        if (BGM_Muted) // ���ҰŰ� �ƴ� ���
        {
            // ������ -80���� �����Ͽ� �ּҷ� ���� (���Ұ� ����)
            m_AudioMixer.SetFloat("BGM", -80f);
            m_MusicBGMSlider.value = 0f;
            BGM_Muted = false; // ���Ұ� ���·� ����
        }
        else // ���Ұ��� ���
        {
            // ������ ���� ������ ����
            m_AudioMixer.SetFloat("BGM", 0f);
            m_MusicBGMSlider.value = 0.5f;
            BGM_Muted = true; // ���Ұ� ���� ����
        }
    }

    public void Toggle_SFX_Mute()
    {
        // ���� ���Ұ� ���¿� ���� ���� ����
        if (SFX_Muted) // ���ҰŰ� �ƴ� ���
        {
            // ������ -80���� �����Ͽ� �ּҷ� ���� (���Ұ� ����)
            m_AudioMixer.SetFloat("SFX", -80f);
            m_MusicSFXSlider.value = 0f;
            SFX_Muted = false; // ���Ұ� ���·� ����
        }
        else // ���Ұ��� ���
        {
            // ������ ���� ������ ����
            m_AudioMixer.SetFloat("SFX", 0f);
            m_MusicSFXSlider.value = 0.5f;
            SFX_Muted = true; // ���Ұ� ���� ����
        }
    }

    public void Toggle_Skill_Voice_Mute()
    {
        // ���� ���Ұ� ���¿� ���� ���� ����
        if (Skill_Voice_Muted) // ���ҰŰ� �ƴ� ���
        {
            // ������ -80���� �����Ͽ� �ּҷ� ���� (���Ұ� ����)
            m_AudioMixer.SetFloat("Skill_Voice", -80f);
            m_MusicSkill_VoiceSlider.value = 0f;
            Skill_Voice_Muted = false; // ���Ұ� ���·� ����
        }
        else // ���Ұ��� ���
        {
            // ������ ���� ������ ����
            m_AudioMixer.SetFloat("Skill_Voice", 0f);
            m_MusicSkill_VoiceSlider.value = 0.5f;
            Skill_Voice_Muted = true; // ���Ұ� ���� ����
        }
    }
}
