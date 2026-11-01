using System;
using UnityEngine;
using static CuttingCounter;
public interface IHasProgress
{
    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;

    public class OnProgressChangedEventArgs : EventArgs
    {
        public float progressNormilized;
    }
}
