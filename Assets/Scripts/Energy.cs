using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    private Button _button;
    private Slider _energySlider;
    private TextMeshProUGUI _energyText;
    private float _maxEnergy;
    public GameObject ButtonGameObject;
    public float CurrentEnergy;
    public GameObject EnergyGameObject;
    public GameObject SliderGameObject;

    private void Start()
    {
        _energyText = EnergyGameObject.GetComponent<TextMeshProUGUI>();
        _energySlider = SliderGameObject.GetComponent<Slider>();
        _maxEnergy = _energySlider.maxValue;
        CurrentEnergy = _energySlider.value;
        _button = ButtonGameObject.GetComponent<Button>();
    }

    public void AddEnergy(float energy)
    {
        if (CurrentEnergy + energy <= _maxEnergy)
        {
            _energySlider.value += energy;
            CurrentEnergy = _energySlider.value;
        }
        else
        {
            _energySlider.value = _maxEnergy;
            CurrentEnergy = _maxEnergy;
        }

        if (CurrentEnergy == _maxEnergy) 
            _button.interactable = true;
        _energyText.text = CurrentEnergy.ToString();

    }
}