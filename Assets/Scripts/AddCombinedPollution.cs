using UnityEngine;

public class AddCombinedPollution : MonoBehaviour
{
    public void AddCombinedPullution()
    {
        CombinedPollution.TotalPollution += FindObjectOfType<Pollution>().PollutionAmount;
    }
}