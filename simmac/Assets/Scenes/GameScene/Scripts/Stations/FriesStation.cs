using UnityEngine;

public class FriesStation : SceneStation
{
    public override void OnClick()
    {
        GameManager.instance.minigameAttributes.type = OrderableItem.Type.Fries;
        base.OnClick();
    }
}
