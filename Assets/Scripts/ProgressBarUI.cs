using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;

    [SerializeField] private Image barImage;

    void Start()
    {
        cuttingCounter.OnProgressChanged += CuttingCounter_OnProgressChanged;

        barImage.fillAmount = 0f;
    }

    private void CuttingCounter_OnProgressChanged(object sender, CuttingCounter.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormilized;
    }

    void Update()
    {
        
    }
}
