using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildlingCard : MonoBehaviour
{
    public WesterosCardReference westerosCardReference;
    public GameObject token;
    public GameObject[] points;
    public int pointsIndex;
    public float speed;
    public void Start()
    {
        token.transform.position = points[1].transform.position;
        pointsIndex = 1;
    }

    public void Update()
    {
        token.transform.position = Vector3.MoveTowards(token.transform.position, points[pointsIndex].transform.position, speed * Time.deltaTime);
    }

    public void GetCard()
    {
        print("Карта взята");
    }
    //public bool isVictory;
    /// <summary>
    /// Метод разыгрывает карту "Сбор на Молоководной" при нашествии одичалых.
    /// </summary>
    public void MassingOnTheMilkwater()                     // Сбор на Молоководной.
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
    /// <summary>
    /// Метод разыгрывает карту "Король за стеной" при нашествии одичалых.
    /// </summary>
    public void AKingBeyondTheWall()                        // Король за стеной.
    {
        // Победа одичалых:
        if (westerosCardReference.isVictory == false)
        {
            // Низжая ставка, отступает на последнее деление всех треков влияния.
            // Все прочие: в порядке хода каждый игрок отступает на последнее деление трека вотчин или двора (по своему выбору).
        }

        // Победа Ночного дозора:
        if (westerosCardReference.isVictory == true)
        {
            // Высшая ставка продвигается на первое деление любого трека влияния и забирает соответствующий жетон превосходства.
        }
    }
    public void MammothRiders()                             // Наездники на мамонтах.
    {
        // Победа одичалых:
        if (westerosCardReference.isVictory == false)
        {
            // Низжая ставка теряет 3 любых отряда.
            // Все прочие: теряют по 2 любых отряда.
        }

        // Победа Ночного дозора:
        if (westerosCardReference.isVictory == true)
        {
            // Высшая ставка может выбрать из своего сброса 1 карту Дома и забрать её на руку.
        }
    }
    public void CrowKillers()                               // Убийца воронов.
    {
        // Победа одичалых:
        if (westerosCardReference.isVictory == false)
        {
            // Низжая ставка заменяет всех своих рыцарей доступными воинами. Рыцари, которых некем заменить, гибнут.
            // Все прочие: заменяют пешими воинами по 2 любых своих рыцаря. Рыцари, которых некем заменить, гибнут.
        }

        // Победа Ночного дозора:
        if (westerosCardReference.isVictory == true)
        {
            // Высшая ставка может тут же заменить до 2 любых своих пеших воинов доступными рыцарями.
        }
    }
    public void TheHordeDescends()                          // Наступление орды.
    {
        // Победа одичалых:
        if (westerosCardReference.isVictory == false)
        {
            // Низжая ставка теряет 2 отряда в одном из своих замков или крепостей. Если таких отрядов нет, теряет 2 любых отряда.
            // Все прочие: теряют по 1 любому отряду.
        }

        // Победа Ночного дозора:
        if (westerosCardReference.isVictory == true)
        {
            // Высшая ставка может собрать войска по обычным правилам сбора в любом подвластном замке или крепости.
        }
    }
    public void SkinchangerScout()                          // Разветчик оборотень.
    {
        // Победа одичалых:
        if (westerosCardReference.isVictory == false)
        {
            // Низжая ставка теряет 2 отряда в одном из своих замков или крепостей. Если таких отрядов нет, теряет 2 любых отряда.
            // Все прочие: теряют по 1 любому отряду.
        }

        // Победа Ночного дозора:
        if (westerosCardReference.isVictory == true)
        {
            // Высшая ставка может собрать войска по обычным правилам сбора в любом подвластном замке или крепости.
        }
    }
    public void RattleshirtsRaiders()                       // Разбойники Гремучей Рубашки.
    {
        // Победа одичалых:
        if (westerosCardReference.isVictory == false)
        {
            // Низжая ставка отступает на 2 деления назад по треку снабжения (не ниже нуля).
            // Все прочие: отступают на 1 деление назад по треку снабжения (не ниже нуля).
        }

        // Победа Ночного дозора:
        if (westerosCardReference.isVictory == true)
        {
            // Высшая ставка продвигается на 1 деление вперед по треку снабжения (не выше 6).
        }
    }
    public void SilenceAtTheWall()                          // Тишина у стены.
    {
        // Победа одичалых:
        if (westerosCardReference.isVictory == false)
        {
            // Низжая ставка не карается.
            // Все прочие: не караются.
        }

        // Победа Ночного дозора:
        if (westerosCardReference.isVictory == true)
        {
            // Высшая ставка не награждается.
        }
    }
    public void PreemptiveRaid()                            // Передовой отряд.
    {
        // Победа одичалых:
        if (westerosCardReference.isVictory == false)
        {
            // Низжая ставка на свой выбор либо
            // а) теряет 2 любых отряда, либо
            // б) отступает на 2 деления по тому треку влияния, где у неё наилучшая позиция.
            // Все прочие: на караются.
        }

        // Победа Ночного дозора:
        if (westerosCardReference.isVictory == true)
        {
            // Высшая ставка не участвует в торгах (и в распределении наград и штрафов по итогам)
            // за отражение атаки одичалых, которые тут же нападают снова с силой 6.
        }
    }
}
