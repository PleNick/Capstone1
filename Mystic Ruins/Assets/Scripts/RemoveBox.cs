using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBox : MonoBehaviour
{
    bool isInteract;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)  //�� Ʈ���Ű� �ƴѰ�? Enter�� Exit�� ��� �����ϴ°�?
    {
        if (other.gameObject.CompareTag("Fire"))
            isInteract = true;
    }

    
}
