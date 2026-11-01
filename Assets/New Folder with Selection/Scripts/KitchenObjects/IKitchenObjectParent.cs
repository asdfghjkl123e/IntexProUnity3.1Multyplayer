using UnityEngine;

public interface IKitchenObjectParent
{
    public void SetKitchenObject(KitchenObject kitchenObject);

    public void ClearKitchenObject();

    public KitchenObject GetKitchenObject();

    public bool HasKitchenObject();

    public Transform GetKitchenObjectFollowTransform();
}
