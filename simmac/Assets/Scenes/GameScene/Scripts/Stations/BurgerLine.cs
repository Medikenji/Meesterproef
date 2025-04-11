using UnityEngine;

/*
 * Burger – (8842, 8842)
 * 8842 feels meaty, solid, and structured.
 * The double 8s represent thick burger patties stacked together.
 * The 4 and 2 act like the bun ends holding it all in place.
 * It’s a symmetrical number that has visual and flavorful weight.
 * Burgers are bold, and this number gives off a similar hearty energy.
 */


public class BurgerLine : SceneStation
{
    public override void OnClick()
    {
        GameManager.instance.minigameModifier.type = OrderableItem.Type.Burger;
        base.OnClick();
    }
}
