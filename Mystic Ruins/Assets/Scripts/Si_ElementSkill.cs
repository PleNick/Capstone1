using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Si_ElementSkill : MonoBehaviour
{
    int time=0;
    bool isActive = false;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 100)
        {
            //���� �׷α� �ִϸ��̼�
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (isActive && gameObject.CompareTag("Water"))
        {
            //������ ���⿡ �߰�
            //if������ �������϶�
                time++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(isActive && gameObject.CompareTag("Fire"))
        {
            //�������� ������
        }
        if(isActive && gameObject.CompareTag("Water"))
        {
            //������ ������ �� ����
        }
    }

}
