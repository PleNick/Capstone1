using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int[] items = new int[4];

    void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = DataManager.Instance.gameData.items[i];
        }
    }

    void AddItem(GameObject item)   //�� �Լ��� �÷��̾� ��ũ��Ʈ���� ��ü�� ��ȣ�ۿ��� �� ȣ���Ű���� ��.
    {
        int n = 0;
        while(n < items.Length) 
        {
            /*if (items[n] == 0)
                items[n] = item.GetComponent<ItemScript>().itemNum; //�� ȹ�� ���� �����۸��� �ĺ���ȣ �ΰ� �� �ĺ���ȣ�� ����
            */                                                      //Ȥ�� �׳� �� �������� �������� �����ϴ� �迭�� �ΰ�, �� �迭�� �ε����� ����
        }
    }
}
