using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEngine : MonoBehaviour
{
    public GameObject player;
    public GameObject cart;

    GameObject coal;
    GameObject cartCoal;

    bool isCart;
    bool isPlayer;
    bool isFire;

    void Start()
    {
        /*
        coal = this.transform.GetChild(0).gameObject;
        cartCoal = cart.transform.GetChild(0).gameObject;

        if(DataManager.Instance.gameData.mapProgress[7] == 0)
            coal.SetActive(false);
        else if(DataManager.Instance.gameData.mapProgress[7] == 1)
            coal.SetActive(true);
            ���� ����Ʈ ����
        else
            ���� ����Ʈ ����
         */
    }

    void Update()
    {
        if(isCart && isPlayer && Input.GetKeyDown(KeyCode.E) && DataManager.Instance.gameData.mapProgress[7] == 0)
        {
            DataManager.Instance.gameData.mapProgress[7] = 1;
            /*coal.SetActive(true);
            cartCoal.SetActive(false);*/
        }     
        
        if(isFire && DataManager.Instance.gameData.mapProgress[7] == 1)
        {
            DataManager.Instance.gameData.mapProgress[7] = 2;
            //��ź�� ������ ����Ʈ ���� (�Ǵ� ��ź ���� ������ �ޱ��� ������� ����)
            //�ٸ� ��Ÿ ���� �ذ� ���� ����Ʈ ����
        }

        /*
        if(){}  //���൵�� 2�̰� �������� �� �������� ��� �ذ�Ǿ������� ��������, 
                //���� ���ų� ���Ⱑ ������ ����Ʈ �����ϰ� �ذ�� �������� ���Ͽ� ���� �ǽ��� �ִϸ��̼� ���
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cart"))
            isCart = true;

        if (other.gameObject.CompareTag("Player"))
            isPlayer = true;

        if (other.gameObject.CompareTag("Fire"))
            isFire = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cart"))
            isCart = false;

        if (other.gameObject.CompareTag("Player"))
            isPlayer = false;
    }
}
