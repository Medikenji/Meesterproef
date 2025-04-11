using UnityEngine;

public class DessertStation : SceneStation
{
    public override void OnClick()
    {
        GameManager.instance.minigameModifier.type = OrderableItem.Type.Icecream;
        base.OnClick();
    }
}
