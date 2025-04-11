using UnityEngine;

public class BurgerLine : SceneStation
{
    public override void OnClick()
    {
        GameManager.instance.minigameAttributes.type = OrderableItem.Type.Burger;
        base.OnClick();
    }
}
