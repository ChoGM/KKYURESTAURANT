using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip musicClip; // �ν����� â���� ������ ���� ����
    private AudioSource musicSource;

    void Start()
    {
        // AudioSource ������Ʈ�� ��������
        musicSource = GetComponent<AudioSource>();

        // ���� ���� ����
        musicSource.clip = musicClip;

        // �뷡 ���
        musicSource.Play();
    }

    void Update()
    {
        // (�ɼ�) �뷡�� �ݺ��Ϸ��� �Ʒ� �ּ� ����
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
}
