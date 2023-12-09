using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePulley : MonoBehaviour
{
    public GameObject player;
    public GameObject cart;

    public bool isDetect;
    public int value;

    Animator anim;
    PlayerMovement2 pm;

    int state;

    void Start()
    {
        state = DataManager.Instance.gameData.pulleyState[value - 1];
        anim = GetComponent<Animator>();
        pm = player.GetComponent<PlayerMovement2>();
    }

    void Update()
    {
        if (isDetect)
        {
            isDetect = false;

            pm.isInteract = false;
            pm.setCart = false;
            pm.cart.transform.parent = null;
            pm.speed = 10f;

            cart.transform.SetParent(this.transform, true);

            if (state == 0)
            {
                state = 1;
                DataManager.Instance.gameData.pulleyState[value - 1] = 1;

                anim.SetInteger("downState", 1);
            }
            else
            {
                anim.SetInteger("downState", 2);
            }
        }
    }

    void ResetUpState()
    {
        anim.SetBool("upState", false);
        //���⿡ restrict ����̳� �ٸ� �͵��� ���½�Ű�� ���� ���� ������
    }
    //�������� �б� ����
    //������ ���� ������ ����
    //������ �þ� ������ �� ���ֱ�
    //�� ���


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("www");
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("upState", true);
            anim.SetFloat("upSpeed", 1);
            anim.SetInteger("downState", 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("weee");
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetFloat("upSpeed", 0);
        }
    }
}
