using System.Collections;
using UnityEngine;

public class RecoloringController : MonoBehaviour
{
    [SerializeField] private GameObject _cubesParent;
    [SerializeField] private float _recoloringInterval;

    private CubeColor[] _cubes;

    public void GetCubesFromParent()
    {
        _cubes = _cubesParent.GetComponentsInChildren<CubeColor>();
    }

    public void StartRecoloring()
    {
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        var newColor = GenerateRandomColor();

        foreach (var cube in _cubes)
        {
            cube.StartChangingColor(newColor);
            yield return new WaitForSeconds(_recoloringInterval);
        }
    }

    private Color GenerateRandomColor()
    {
        return Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f);
    }
}