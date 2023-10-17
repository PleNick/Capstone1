using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sh_PushPipe : MonoBehaviour
{
    public GameObject player;

    bool isPush;

    void Start()
    {
        isPush = false;
    }

    void Update()
    {
        if(isPush)
        {
            bool x = (player.transform.position.x > 0 ? true : false);
            bool z = (player.transform.position.y > 0 ? true : false);
            Debug.Log("����" + x + "      " + z);
            if (!x && z)
            {
                if (Input.GetKeyDown(KeyCode.D))
                    StartCoroutine(Push(x, z, true));
                Debug.Log("�̰͵� �ǳ�");
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPush = true;
            if(player.transform.parent == null)
                player.transform.SetParent(transform, true);
        }
        Debug.Log("�̰� �ǳ�");
    }

    IEnumerator Push(bool x, bool z, bool isShi)
    {
        int n = 0;
        int dir = (isShi ? 1 : -1);
        Debug.Log("�̰͵� �ǳ�2");
        while (n < 90)
        {
            yield return new WaitForSeconds(0.001f);
            
            transform.Rotate(0, 0, dir);
            yield return null;
            n++;
        }
        isPush = false;
    }

}
