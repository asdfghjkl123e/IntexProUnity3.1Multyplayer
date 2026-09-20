using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO KitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        this.clearCounter = clearCounter;
    }
    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
