using System.Collections;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private AudioSource startGameSound;
    private GameObject UI;
    // Создание экрана запуска
    private void Awake()
    {
        UI = GameObject.Find("PlayerUI");
        UI.SetActive(false);
        startGameSound = GetComponent<AudioSource>();
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart()
    {
        startGameSound.Play();
        yield return new  WaitForSeconds(1.5f);
        UI.SetActive(true);
    }
}
