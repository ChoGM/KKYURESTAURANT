using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BookTest : MonoBehaviour
{
    [SerializeField] float pagesSpeed = 0.5f;
    [SerializeField] List<Transform> pages;  // RectTransform ��� Transform�� ���

    int index = 0;
    bool isRotating = false;

    public void RotateForward()
    {
        if (!isRotating && index < pages.Count - 1)
        {
            float angle = 180f;
            StartCoroutine(Rotate(angle, true));
        }
        else if (index >= pages.Count - 1)
        {
            Debug.LogWarning("�� �̻� ������ ���� �� �����ϴ�. ������ �������� �����߽��ϴ�.");
        }
    }

    public void RotateBack()
    {
        if (!isRotating && index > 0)
        {
            float angle = 0f;
            StartCoroutine(Rotate(angle, false));
        }
        else if (index <= 0)
        {
            Debug.LogWarning("�� �̻� �ڷ� ���� �� �����ϴ�. �̹� ù �������� �ֽ��ϴ�.");
        }
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        if (isRotating)
        {
            Debug.LogWarning("�̹� ȸ�� ���Դϴ�.");
            yield break;
        }

        isRotating = true;

        if (forward)
        {
            index++;
            if (index >= pages.Count)
            {
                index = pages.Count - 1;
                isRotating = false;
                yield break;
            }
        }
        else
        {
            index--;
            if (index < 0)
            {
                index = 0;
                isRotating = false;
                yield break;
            }
        }

        float value = 0f;
        while (value < 1f)
        {
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pagesSpeed;
            value = Mathf.Clamp01(value);

            if (index >= 0 && index < pages.Count)
            {
                pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value);

                float angleDiff = Quaternion.Angle(pages[index].rotation, targetRotation);
                if (angleDiff < 0.1f)
                {
                    // �ε����� ����Ǿ����Ƿ� �ڷ�ƾ ����
                    break;
                }
            }
            else
            {
                Debug.LogError("��ȿ���� ���� �ε���: " + index);
                // �ε����� �߸��Ǹ� �ڷ�ƾ ����
                break;
            }

            yield return null;
        }

        isRotating = false; // ȸ���� �������Ƿ� �÷��׸� false�� ����
    }
}
