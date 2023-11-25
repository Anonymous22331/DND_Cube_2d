using UnityEngine;
using UnityEngine.UI;
// ����� ��� ������ � �������������
public class Modifier
{
    public string name;
    public int amount;

    // ��������� � �������� ������������
    public void SetVisibility()
    {
        var modifier = GameObject.Find(name);
        if (amount != 0) {
            modifier.GetComponentInChildren<Image>().enabled = true;
            modifier.transform.GetChild(0).GetComponentInChildren<Text>().text = amount.ToString();
        }
        else
        {
            modifier.GetComponentInChildren<Image>().enabled = false;
            modifier.transform.GetChild(0).GetComponentInChildren<Text>().text = "";
        }

    }
}
