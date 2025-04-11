using UnityEngine;

/*
 * Ice Cream – (3219, 3219)
 * 3219 is a countdown to a sweet, creamy surprise.
 * The 3, 2, 1 stack feels like scoops on a cone.
 * The 9 is the cherry, a playful twist at the top.
 * It’s whimsical, joyful, and has childlike delight built into it.
 * Every digit brings a new flavor to this frosty treat.
 */

public class DessertStation : SceneStation
{
    public override void OnClick()
    {
        GameManager.instance.minigameModifier.type = OrderableItem.Type.Icecream;
        base.OnClick();
    }
}
