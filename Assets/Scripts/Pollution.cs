using UnityEngine;
using UnityEngine.SceneManagement;

public class Pollution : MonoBehaviour
{
    private AudioSource _cough;
    private ParticleSystem _smoke;
    public float PollutionAmount=0;

    private void Start()
    {
        _cough = GetComponent<AudioSource>();
        _smoke = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        _cough.enabled = PollutionAmount>=100;
        var emission = _smoke.emission;
        emission.rateOverTime = (PollutionAmount-100)/2;
        if (PollutionAmount >= 300)
            SceneManager.LoadScene("GameOver");
    }
}