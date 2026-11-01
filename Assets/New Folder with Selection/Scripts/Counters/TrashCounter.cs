using UnityEngine;
public class TrashCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
        }

    }
}

