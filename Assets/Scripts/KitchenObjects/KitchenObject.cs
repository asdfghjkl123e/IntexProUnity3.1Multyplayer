using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO KitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetkitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitchenObjectParent;
        kitchenObjectParent.SetKitchenObject(this);

        if(kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("kitchenObjectParent already has a KitchenObject");
        }

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    

    public IKitchenObjectParent GetkitchenObjectParent()
    {
        return kitchenObjectParent;
    }
}
