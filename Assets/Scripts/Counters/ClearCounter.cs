using UnityEngine;

public class ClearCounter : BaseCounter, IKitchenObjectParent
{
    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            if(player.HasKitchenObject())
            {
                player.GetKitchenObject().SetkitchenObjectParent(this);
            }
            else
            {
                //nothing
            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                //nothing
            }
            else
            { 
                GetKitchenObject().SetkitchenObjectParent(player);
            }
        }
    }
}
