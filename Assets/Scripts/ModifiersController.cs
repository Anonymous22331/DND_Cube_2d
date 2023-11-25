using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ModifiersController: MonoBehaviour
{
    public Modifier strength = new Modifier() { name = "Strength", amount = 0 };
    public Modifier agility = new Modifier() { name = "Agility", amount = 0 };
    public Modifier intellegence = new Modifier() { name = "Intellegence", amount = 0 };

    // Установить показатель модификатора
    public void SetModifier()
    {
        var power = EventSystem.current.currentSelectedGameObject;
        string input = power.transform.GetChild(1).GetComponentInChildren<Text>().text;
        try
        {
            if (power.name == "AddStrength")
            {
                strength.amount = Convert.ToInt32(input);
                strength.SetVisibility();
            }
            
            if (power.name == "AddAgility")
            {
                agility.amount = Convert.ToInt32(input);
                agility.SetVisibility();
            }
            
            if (power.name == "AddIntellegence")
            {
                intellegence.amount = Convert.ToInt32(input);
                intellegence.SetVisibility();
            }
           
            
        }
        catch
        {
            Debug.Log("Cant convert to int");
        }
    }
}
