using System.Collections;
using UnityEngine;

public class CubeColor : MonoBehaviour
{
    [SerializeField] private float _recoloringTime;

    private Renderer _renderer;
    private Color _startColor;
    private Color _nextColor;
    private float _recoloringTimer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private IEnumerator ChangeColor()
    {
        _recoloringTimer = 0;
        while (_recoloringTime > _recoloringTimer)
        {
            _recoloringTimer += Time.deltaTime;

            var progress = _recoloringTimer / _recoloringTime;
            Color.Lerp(_startColor, _nextColor, progress);
            _renderer.material.color = Color.Lerp(_startColor, _nextColor, progress);

            yield return null;
        }
    }

    public void StartChangingColor(Color newColor)
    {
        _startColor = _renderer.material.color;
        _nextColor = newColor;
        StartCoroutine(ChangeColor());
    }
}