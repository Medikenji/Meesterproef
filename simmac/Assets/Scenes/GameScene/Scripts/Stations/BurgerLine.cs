using UnityEngine;

public class BurgerLine : SceneStation
{
    public override void OnClick()
    {
        GameManager.instance.minigameModifier.type = OrderableItem.Type.Burger;
        base.OnClick();
    }
}
