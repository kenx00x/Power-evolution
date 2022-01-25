using UnityEngine;

public class AddEnergy : MonoBehaviour
{
    private Energy _energy;
    private float _timeElapsed;
    public float energyAmount = 10f;
    public float energyPrice = 20f;
    public float energyRate = 1f;

    private void Start()
    {
        if (!gameObject.CompareTag("Object")) return;
        _energy = FindObjectOfType<Energy>();
        _energy.AddEnergy(energyPrice*-1);
    }

    private void FixedUpdate()
    {
        if (!gameObject.CompareTag("Object")) return;
        if (_timeElapsed >= energyRate)
        {
            _energy.AddEnergy(energyAmount);
            _timeElapsed = 0f;
        }
        _timeElapsed += Time.deltaTime;
    }
}