using UnityEngine;

public class AddPollution : MonoBehaviour
{
    public float Pollution = 0;

    private void Start()
    {
        var pollution = FindObjectOfType<Pollution>();
        if ((pollution.PollutionAmount+Pollution>=0) & gameObject.CompareTag("Object")) 
            pollution.PollutionAmount += Pollution;
    }
}