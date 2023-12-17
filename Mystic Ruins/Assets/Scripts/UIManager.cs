using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject titleB;
    public GameObject quitB;
    public GameObject script;
    public GameObject itemPointer;
    public GameObject itemsUI;
    public GameObject battleUI;

    public float duration;
    public float hintPrintTime;
    public int itemPointerNum;

    Dictionary<int, string> hintData = new Dictionary<int, string>();

    void Start()
    {
        if (DataManager.Instance.gameData.currentMapValue == 8)
            FadeHintText();

        itemPointer.transform.localPosition = new Vector3(-165,
                itemPointer.transform.localPosition.y, itemPointer.transform.localPosition.z);

        itemPointerNum = 0;

        titleB.SetActive(false);
        quitB.SetActive(false);

        setHint();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PrintMenu();

        float scrollInput = Input.GetAxisRaw("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            itemPointer.transform.localPosition = new Vector3(itemPointer.transform.localPosition.x - scrollInput * 1100,
                itemPointer.transform.localPosition.y, itemPointer.transform.localPosition.z);

            if (itemPointer.transform.localPosition.x > 165)
                itemPointer.transform.localPosition = new Vector3(165,
                itemPointer.transform.localPosition.y, itemPointer.transform.localPosition.z);

            if (itemPointer.transform.localPosition.x < -165)
                itemPointer.transform.localPosition = new Vector3(-165,
                itemPointer.transform.localPosition.y, itemPointer.transform.localPosition.z);

            itemPointerNum = (int)((itemPointer.transform.localPosition.x + 165) / 110);
        }       
    }

    public void PrintHint()
    {
        int key = DataManager.Instance.gameData.currentMapValue * 10 +
            DataManager.Instance.gameData.mapProgress[DataManager.Instance.gameData.currentMapValue];

        script.GetComponent<TextMeshProUGUI>().text = hintData[key];

        StartCoroutine(FadeHintText());
    }

    IEnumerator FadeHintText()
    {
        TextMeshProUGUI hintText = script.GetComponent<TextMeshProUGUI>();

        float time = 0f;
        Color color = hintText.color;
        Color targetColor = new Color(color.r, color.g, color.b, 1f);

        while (time < 1f)
        {
            hintText.color = Color.Lerp(color, targetColor, time);
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(hintPrintTime);

        time = 0f;
        color = hintText.color;
        targetColor = new Color(color.r, color.g, color.b, 0f);

        while (time < 1f)
        {
            hintText.color = Color.Lerp(color, targetColor, time);
            time += Time.deltaTime;
            yield return null;
        }
    }

    void setHint()
    {
        hintData.Add(0, "�̻��� ���̳�.. �ϴ� ������ ���ư�����!");
        hintData.Add(1, "�� ������ ����..?");
        hintData.Add(10, "�� ��ġ�� �ѹ� �Ẹ�°� ���ھ�..");
        hintData.Add(20, "������ ����..�и����� �ʳ�");
        hintData.Add(21, "��ź�� ������..�ʿ����� ������?");
        hintData.Add(30, "ȭ�ο� �ѹ� ������ ������");
        hintData.Add(31, "���� �ذ��Ѱ� ����!");
        hintData.Add(40, "��갡 �ʹ� ����..�ö󰥼� �������Ѱ� ������?");
        hintData.Add(41, "���� ä���߰ھ�..��� ����?");
        hintData.Add(42, "�� ��������� ������ ������..");
        hintData.Add(43, "���� �ذ��Ѱ� ����!");
        hintData.Add(50, "�������� �����ؾ� �Ұ� ����.. ����� ������...?");
        hintData.Add(51, "�������� ������?");
        hintData.Add(60, "������ �� ���ſ�� �ʿ���..!");
        hintData.Add(61, "�� �������� ����..?");
        hintData.Add(70, "������ ��������..ȭ���� �ʿ��ҰͰ���! ������� ���غ���..?");
        hintData.Add(71, "���ᰡ ������..���� �ٿ��߰ھ�!");
        hintData.Add(72, "�̰����� ���� �ذ�ȰͰ���!");
        hintData.Add(80, "���Թ���...? ����..? ������ ������");
        hintData.Add(81, "������! ���� �����߷��߰ھ�..");
        hintData.Add(82, "�� ���踦 ��ġ�� �Ẹ��!");
    }

    public void PrintMenu()
    {
        if (titleB.activeSelf && quitB.activeSelf)
        {
            titleB.SetActive(false);
            quitB.SetActive(false);
        }
        else
        {
            titleB.SetActive(true);
            quitB.SetActive(true);
        }
    }

    public void UiSwhitch()
    {
        StartCoroutine(UISwitching());
    }

    IEnumerator UISwitching()
    {
        itemPointer.transform.SetParent(itemsUI.transform, true);

        Transform openUI = itemsUI.transform;
        Transform closeUI = battleUI.transform;

        if (itemsUI.transform.position.y > battleUI.transform.position.y)
        {
            Transform tmp = openUI;
            openUI = closeUI; closeUI = tmp;
        }

        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            closeUI.position = Vector3.Lerp(closeUI.position, new Vector3(closeUI.position.x, -150f, closeUI.position.z), t);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            openUI.position = Vector3.Lerp(openUI.position, new Vector3(openUI.position.x, 0f, openUI.position.z), t);
            openUI.position = Vector3.Lerp(openUI.position, new Vector3(openUI.position.x, 0f, openUI.position.z), t);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        itemPointer.transform.SetParent(itemsUI.transform.parent, true);
        /*itemPointer.transform.position = new Vector3(itemPointer.transform.position.x,
            itemsUI.transform.position.y + 59, itemPointer.transform.position.z);*/
    }

}


