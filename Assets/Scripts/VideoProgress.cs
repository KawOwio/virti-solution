using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoProgress : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private VideoPlayer videoPlayer = null; // Video player component

    private Image progress; // Image of the progress bar

    void Awake()
    {
        progress = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.frameCount > 0)
        {
            progress.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }
    }

    // For dragging on the proggress bar
    public void OnDrag(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    // For clicking the progress bar
    public void OnPointerDown(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    // Check for input on the progress bar
    private void TrySkip(PointerEventData eventData)
    {
        Vector2 localPoint;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            progress.rectTransform, eventData.position, null, out localPoint))
        {
            float percent = Mathf.InverseLerp(progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax, localPoint.x);

            SkipToPercent(percent);
        }
    }

    // Rewind/Forward the video
    private void SkipToPercent(float percent)
    {
        float frame = videoPlayer.frameCount * percent;
        videoPlayer.frame = (long)frame;
    }
}
