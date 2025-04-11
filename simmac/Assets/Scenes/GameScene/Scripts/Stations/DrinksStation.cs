using UnityEngine;

/*
 * Milkshake – (7055, 7055)
 * 7055 feels like a thick swirl in a cold cup.
 * The 7 adds a whipped-cream twist on top.
 * The double 5s represent creamy, indulgent consistency and flavor.
 * It’s retro, cool, and feels like a jukebox number in a diner.
 * Perfectly smooth, perfectly sweet, like a sip of nostalgia.
 */

public class DrinksStation : SceneStation
{
    public override void OnClick()
    {
        GameManager.instance.minigameModifier.type = OrderableItem.Type.Milkshake;
        base.OnClick();
    }
}
