using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Window : MonoBehaviour
{
    [Header("References")]
    public RawImage barIcon;
    public TextMeshProUGUI barTitle;

    public WindowData data;
    private bool _isHidden = true;
    private Coroutine _showing;
    private Coroutine _hiding;
    private ClickableIcon _taskbarIcon;

    public bool isFocused = false;

    private readonly float _animDuration = 0.2f;

    private void Start()
    {
        if (data.showOnTaskbar)
        {
            _taskbarIcon = Instantiate(OSManager.instance.iconPrefab, OSManager.instance.taskbarIconPool)
                .GetComponent<ClickableIcon>();
            _taskbarIcon.SetLink(this);
        }

        barIcon.texture = data.icon;
        barTitle.SetText(data.name);
    }

    public void Show(Vector2 startPos)
    {
        // Currently playing this animation, don't touch it
        if (_showing != null || !_isHidden)
            return;

        transform.position = startPos;
        gameObject.SetActive(true);

        _showing = StartCoroutine(ShowCoroutine(startPos));
    }

    public IEnumerator ShowCoroutine(Vector2 startPos)
    {


        float t = 0;
        while (t < _animDuration)
        {
            float currentTime = (t / _animDuration);
            transform.position = Vector2.Lerp(startPos, Vector2.zero, currentTime);
            transform.localScale = Vector3.Lerp(new Vector3(0,0,1), Vector3.one, currentTime);

            t += Time.deltaTime;
            yield return null;
        }

        _isHidden = false;
        _showing = null;
    }


    public void Hide() => Hide(_taskbarIcon.transform.position);
    public void Hide(Vector2 endPos)
    {
        if (_hiding != null || _isHidden)
            return;

        _hiding = StartCoroutine(HideCoroutine(endPos));
    }

    public IEnumerator HideCoroutine(Vector2 endPos)
    {
        Vector2 startScale = transform.localScale;
        Vector2 startPos = transform.position;

        float t = 0;
        while (t < _animDuration)
        {
            float currentTime = (t / _animDuration);
            transform.position = Vector2.Lerp(startPos, endPos, currentTime);
            transform.localScale = Vector3.Lerp(startScale, new Vector3(0,0,1), currentTime);

            t += Time.deltaTime;
            yield return null;
        }

        _isHidden = true;
        _hiding = null;
        
        gameObject.SetActive(false);

    }

    public void Destroy()
    {

        Destroy(_taskbarIcon.gameObject);
        Destroy(gameObject);

    }
}