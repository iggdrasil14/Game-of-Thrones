using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildlingCard : MonoBehaviour
{
    public WesterosCardReference westerosCardReference;

    //public bool isVictory;
    /// <summary>
    /// Метод разыгрывает карту "Сбор на Молоководной" при нашествии одичалых.
    /// </summary>
    public void MassingOnTheMilkwater()     // Сбор на Молоководной.
    {
        // Победа одичалых:
        if (westerosCardReference.isVictory == false) 
        {
            // Низжая ставка, если держит на руке больше одной карты Дома, сбрасывает все карты с наибольшей боевой силой.
            // Все прочие, если держат на руке больше оджной карты Дома, сбрасывают по 1 карте на свой выбор.
        }

        // Победа Ночного дозора:
        if (westerosCardReference.isVictory == true)
        {
            // Высшая ставка забирает на руку весь сброс своих карт Дома.
        }
    }
}
