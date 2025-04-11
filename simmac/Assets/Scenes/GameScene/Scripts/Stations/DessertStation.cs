using UnityEngine;

public class DessertStation : SceneStation
{
    public override void OnClick()
    {
        GameManager.instance.minigameAttributes.type = OrderableItem.Type.Icecream;
        base.OnClick();
    }
}
