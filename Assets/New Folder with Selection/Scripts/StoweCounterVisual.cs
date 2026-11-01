using System;
using UnityEngine;

public class StoweCounterVisual : MonoBehaviour
{
    [SerializeField] private StowCounter stoveCounter;
    [SerializeField] private GameObject stoveOnGameObject;
    [SerializeField] private GameObject particlesGameObject;

    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StowCounter.OnStateChangedEventArgs e)
    {
        bool showVisual = e.state == StowCounter.State.Frying || e.state == StowCounter.State.Fried;
        stoveOnGameObject.SetActive(showVisual);
        particlesGameObject.SetActive(showVisual);
    }
}
