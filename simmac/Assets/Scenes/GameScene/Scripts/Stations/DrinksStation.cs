using UnityEngine;

public class DrinksStation : SceneStation
{
    public override void OnClick()
    {
        GameManager.instance.minigameAttributes.type = OrderableItem.Type.Milkshake;
        base.OnClick();
    }
}
