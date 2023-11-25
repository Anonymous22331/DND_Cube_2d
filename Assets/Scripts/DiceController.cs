using UnityEngine;
using System.Collections;
using Random = System.Random;

public class DiceController : MonoBehaviour
{
    private Animator rollingAnimator;
    private SpriteRenderer _sr;
    private ModifiersController _mc;
    private GoalController _gc;
    private AudioSource _as;
    private Sprite[] diceResult;
    private bool isDiceRolling = false;

    public AudioClip WinSound;
    public AudioClip LoseSound;
    public AudioClip DiceSound;

    private void OnEnable()
    {
        rollingAnimator = gameObject.GetComponent<Animator>();
        _sr = gameObject.GetComponent<SpriteRenderer>();
        diceResult = Resources.LoadAll<Sprite>("Sprites/");
        _mc = GameObject.Find("ModifierController").GetComponent<ModifiersController>();
        _gc = GameObject.Find("GoalManager").GetComponent<GoalController>();
        _as = GetComponent<AudioSource>();
    }


    // Запуск по нажатию
    private void OnMouseDown()
    {
        if (!isDiceRolling)
        {
            isDiceRolling = true;
            StartCoroutine(RollDice());
        }
    }
    // Выбор случайного числа 1-20
    private int GetRandomEdge()
    {
        return new Random().Next(19) + 1;
    }
    // Получение значений модификаторов
    private int GetModifiersAmount()
    {
        return _mc.strength.amount + _mc.agility.amount + _mc.intellegence.amount;
    }
    // Вывод результата
    private void GetResult(int currentNumber)
    {
        int goalNumber = _gc.goalNumber;
        if (currentNumber >= goalNumber)
        {
            StartCoroutine(PlaySoundWithDelay(WinSound));
            StartCoroutine(_gc.SetResultScreen(GameObject.Find("Win")));
        }
        else
        {
            StartCoroutine(PlaySoundWithDelay(LoseSound));
            StartCoroutine(_gc.SetResultScreen(GameObject.Find("Fail")));
        }
    }
    // Проигрыш звука с задержкой
    private IEnumerator PlaySoundWithDelay(AudioClip sound)
    {
        yield return new WaitForSeconds(1f);
        _as.PlayOneShot(sound, 0.2f);
    }
    // Бросок кубика
    private IEnumerator RollDice()
    {
        int resultNumber = GetRandomEdge();
        yield return StartCoroutine(StartRollingCoroutine());
        _sr.sprite = diceResult[resultNumber];
        resultNumber += GetModifiersAmount();
        GetResult(resultNumber);
    }
    // Запуск анимации броска
    private IEnumerator StartRollingCoroutine()
    {
        rollingAnimator.enabled = true;
        rollingAnimator.SetBool("IsRolling", true);
        _as.PlayOneShot(DiceSound, 0.8f);
        yield return new WaitForSeconds(2);
        rollingAnimator.SetBool("IsRolling", false);
        rollingAnimator.enabled = false;
        isDiceRolling = false;
    }
}
