using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    public int goalNumber;

    private GameObject _dice;
    private SpriteRenderer _dice_sr;
    private BoxCollider2D _dice_col;
    // �� ������� ������������� ��������
    private void OnEnable()
    {
        goalNumber = 10;
        _dice = GameObject.Find("Dice");
        _dice_sr = _dice.GetComponent<SpriteRenderer>();
        _dice_col = _dice.GetComponent<BoxCollider2D>();
        SetGoal();
    }
    // ���������� ����
    public void SetGoal()
    {
        try
        {
            string inputGoal = GameObject.Find("GoalAmount").GetComponentInChildren<Text>().text;
            if (inputGoal != "")
            {
                goalNumber = Convert.ToInt32(inputGoal);
            }
        }
        catch
        {
            Debug.Log("Cant convert to int");
        }
        if (goalNumber > 0 && goalNumber < 21) {
            GameObject.Find("InviteMessage").GetComponent<Text>().text = "�������� �������������: " + goalNumber.ToString();
        }
    }
    // �������� ����� ������ ��� ���������
    private void SetScreenComponentActive(GameObject winOrLoss, bool active)
    {
        winOrLoss.transform.GetChild(0).GetComponent<Image>().enabled = active;
        winOrLoss.transform.GetChild(1).GetComponent<Text>().enabled = active;
        _dice_sr.enabled = !active;
        _dice_col.enabled = !active;
    }
    // ������� ��������� �� �����
    public IEnumerator SetResultScreen(GameObject winOrLoss)
    {
        yield return new WaitForSeconds(1f);
        GameObject diceScreen = GameObject.Find("DiceScreen");
        diceScreen.SetActive(false);
        SetScreenComponentActive(winOrLoss,true);
        yield return new WaitForSeconds(1.5f);
        SetScreenComponentActive(winOrLoss, false);
        diceScreen.SetActive(true);
    }
}
