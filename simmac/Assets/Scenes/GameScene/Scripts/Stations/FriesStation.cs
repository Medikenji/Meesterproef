using UnityEngine;

public class FriesStation : SceneStation
{
    public override void OnClick()
    {
        GameManager.instance.minigameModifier.type = OrderableItem.Type.Fries;
        base.OnClick();
    }
}
