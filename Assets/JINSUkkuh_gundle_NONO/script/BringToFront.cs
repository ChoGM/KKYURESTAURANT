using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringToFront : MonoBehaviour
{
    void Start()
    {
        // �г��� SortingOrder�� �ֻ����� ����
        GetComponent<Renderer>().sortingOrder = 999;
    }
}
