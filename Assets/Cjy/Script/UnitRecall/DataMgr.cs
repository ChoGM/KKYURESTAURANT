using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Line // ����
{
    Line1, Line2, Line3
}
public class DataMgr : MonoBehaviour
{
    public static DataMgr instance;

    private void Awake()
    {
        //���� 'instance'�� ���� �����Ǿ� ���� �ʾҴٸ�, ������ �ν��Ͻ��� 'instance'�� �Ҵ�
        if (instance == null) instance = this;

        //�̹� 'instance'�� �����Ǿ� �ִٸ�, �ߺ� ������ �������� �޼��带 ���� 
        else if (instance != null) return;

        //���� ���� ������Ʈ�� �� ��ȯ�ÿ� �ı��� �ʵ��� ����
        DontDestroyOnLoad(gameObject);
    }

    //���� ���õ� ������ �����ϴ� ����
    public Line currentLine;
}
