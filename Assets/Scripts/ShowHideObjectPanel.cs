using System.Collections;
using TMPro;
using UnityEngine;

public class ShowHideObjectPanel : MonoBehaviour
{
    private Vector3 _downPos;
    private bool _shown = true;
    private Vector3 _upPos;
    public RectTransform RectTransform;
    public GameObject Text;

    public void Start()
    {
        _upPos = RectTransform.parent.localPosition;
        _downPos = new Vector3(RectTransform.parent.localPosition.x, RectTransform.parent.localPosition.y - 80 , RectTransform.parent.localPosition.z);
    }

    private IEnumerator Lerp(Vector3 target)
    {
        while (Vector3.Distance(RectTransform.parent.localPosition, target) > 0.5f)
        {
            RectTransform.parent.localPosition = Vector3.Lerp(RectTransform.parent.localPosition, target, 2*Time.deltaTime);
            yield return null;
        }
    }

    public void ShowHide()
    {
        StopAllCoroutines();
        if (_shown)
        {
            StartCoroutine(Lerp(_downPos));
            Text.GetComponent<TextMeshProUGUI>().text = "^";
            _shown = false;
        }
        else
        {
            StartCoroutine(Lerp(_upPos));
            Text.GetComponent<TextMeshProUGUI>().text = "V";
            _shown = true;
        }
    }
}