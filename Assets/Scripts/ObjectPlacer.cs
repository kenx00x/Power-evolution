using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    private AudioSource _audioSource;
    private Energy _energy;
    private GameObject _ghostObject;
    private Grid[] _grids;
    public GameObject ObjectToPlace;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _grids = FindObjectsOfType<Grid>();
        _energy = FindObjectOfType<Energy>();
        GhostObject();
    }

    private void Update()
    {
        var renderers = _ghostObject.GetComponentsInChildren<Renderer>();
        if (_energy.CurrentEnergy >= ObjectToPlace.GetComponent<AddEnergy>().energyPrice)
            foreach (var renderer1 in renderers) renderer1.material.color = Color.green;
        else
            foreach (var renderer1 in renderers) renderer1.material.color = Color.red;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo))
            foreach (var grid in _grids)
            {
                var finalPosition = grid.GetNearestPointOnGrid(hitInfo.point);
                if ((finalPosition.x <= grid.xmax) & (finalPosition.x >= grid.xmin) & (finalPosition.z <= grid.zmax) & (finalPosition.z >= grid.zmin) & !hitInfo.collider.CompareTag("Object"))
                {
                    var colliders = Physics.OverlapSphere(finalPosition, grid.size / 4);
                    var hitObject = false;
                    foreach (var collider1 in colliders)
                        if (collider1.CompareTag("Object")) hitObject = true;
                    if (!hitObject)
                    {
                        _ghostObject.SetActive(true);
                        _ghostObject.transform.position = finalPosition;
                        if (Input.GetKeyDown(KeyCode.Mouse0) & (_energy.CurrentEnergy>=ObjectToPlace.GetComponent<AddEnergy>().energyPrice))
                        {
                            Instantiate(ObjectToPlace).transform.position = _ghostObject.transform.position;
                            _audioSource.PlayOneShot(ObjectToPlace.GetComponent<AudioSource>().clip);
                        }
                    }
                    else
                    {
                        _ghostObject.SetActive(false);
                    }
                    break;
                }
                _ghostObject.SetActive(false);
            }
        else
            _ghostObject.SetActive(false);
    }

    public void ChangeObject(GameObject gameObject)
    {
        ObjectToPlace = gameObject;
        Destroy(_ghostObject);
        GhostObject();
    }

    private void GhostObject()
    {
        _ghostObject = Instantiate(ObjectToPlace);
        _ghostObject.tag = "GhostObject";
        foreach (Transform child in _ghostObject.transform)
        {
            child.tag = "GhostObject";
            var childCollider = child.GetComponentInChildren<Collider>();
            DestroyImmediate(childCollider);
        }
        _ghostObject.SetActive(false);
    }
}