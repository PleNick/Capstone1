using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractStove : MonoBehaviour
{
    Animator anim;
    bool isDetect;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isDetect)
        {
            anim.SetBool("isDetect", true);
            
            if(DataManager.Instance.gameData.skillState == 0 && Input.GetKeyDown(KeyCode.E))
            {
                DataManager.Instance.gameData.mapProgress[3] = 1;

                DataManager.Instance.gameData.skillState = 1;
                //��ų ȹ�� ���� ����Ʈ�� �ƽ�, Ʃ�丮�� ���� ����
            }
        }
        else
            anim.SetBool("isDetect", false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDetect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDetect = false;
        }
    }
}
