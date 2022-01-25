using TMPro;
using UnityEngine;

public class SetFinalPollution : MonoBehaviour
{
    private TextMeshProUGUI _pollutionText;
    public GameObject? PollutionScore;

    private void Start()
    {
        if (PollutionScore != null)
        {
            _pollutionText = PollutionScore.GetComponent<TextMeshProUGUI>();
            _pollutionText.text = Mathf.Round(CombinedPollution.TotalPollution).ToString();
        }
        CombinedPollution.TotalPollution = 0;
    }
}