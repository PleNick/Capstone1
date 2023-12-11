using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class ItemManager : MonoBehaviour
{
    public GameObject[] itemImages = new GameObject[4];

    public Sprite[] itemSprites = new Sprite[3];
    //(0)���� / (1)��ź / (2)��ٸ�

    public bool AddItem(int itemValue)
    {         
        int[] items = DataManager.Instance.gameData.items;
        bool isSaved = false;
        int i = 0;
        while(i < items.Length) 
        {
            if (items[i] == 0)
            {
                DataManager.Instance.gameData.items[i] = itemValue;
                itemImages[i].GetComponent<Image>().sprite = itemSprites[itemValue - 1];
                itemImages[i].GetComponent<Image>().enabled = true;
                isSaved = true;
                break;
            }
            i++;
        }

        return isSaved;
    }

    public bool UseItem(int pointerNum, int wantedItemNum)
    {
        if (itemImages[pointerNum].GetComponent<Image>().sprite == itemSprites[wantedItemNum])
        {
            DataManager.Instance.gameData.items[pointerNum] = 0;
            itemImages[pointerNum].GetComponent<Image>().sprite = null;
            itemImages[pointerNum].GetComponent<Image>().enabled = false;

            return true;
        }

        return false;
    }

    //������ ������ ������ ���� ��� �� UI ���� ��� ���� �ʿ�
}
