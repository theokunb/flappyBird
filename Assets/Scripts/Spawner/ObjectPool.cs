using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private GameObject _container;

    private List<GameObject> _pool;
    private Camera _camera;

    protected void Initilize(GameObject template)
    {
        _camera = Camera.main;
        _pool = new List<GameObject>();

        for (int i = 0; i < _capacity; i++)
        {
            var item = Instantiate(template, _container.transform);
            item.SetActive(false);
            _pool.Add(item);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(obj => obj.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAfterScreen()
    {
        var disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach(var element in _pool)
        {
            if(element.activeSelf == true && element.transform.position.x <= disablePoint.x)
            {
                element.SetActive(false);
            }
        }
    }

    public void ResetPool()
    {
        foreach(var element in _pool)
        {
            element.SetActive(false);
        }
    }
}
