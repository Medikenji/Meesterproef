using UnityEngine;

/*
 * Fries – (1133, 1133)
 * 1133 is crisp, light, and satisfying like a fresh batch of fries.
 * The 1s resemble tall, straight fries poking from the top of a box.
 * The 3s curve like fries bending under their own golden weight.
 * It’s a fun number with a quick, addictive rhythm.
 * Just like fries—simple, repeatable, and impossible to eat just one.
 */


public class FriesStation : SceneStation
{
    public override void OnClick()
    {
        GameManager.instance.minigameModifier.type = OrderableItem.Type.Fries;
        base.OnClick();
    }
}
