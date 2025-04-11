using UnityEngine;

public class DrinksStation : SceneStation
{
    public override void OnClick()
    {
        GameManager.instance.minigameModifier.type = OrderableItem.Type.Milkshake;
        base.OnClick();
    }
}
