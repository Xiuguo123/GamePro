using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPanel : MonoBehaviour
{
    public VideoPlayer m_Video;  // 视频播放器组件
    public Slider progressSlider;  // 视频进度滑块

    private void OnEnable()
    {
        m_Video.prepareCompleted += OnVideoReady;  // 视频准备完成时的回调
        m_Video.loopPointReached += OnVideoEnd;  // 视频播放完成时的回调
        progressSlider.onValueChanged.AddListener(OnSliderValueChanged);  // 滑块值改变时的回调
    }

    private void OnDisable()
    {
        m_Video.prepareCompleted -= OnVideoReady;
        m_Video.loopPointReached -= OnVideoEnd;
        progressSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

    private void OnVideoReady(VideoPlayer source)
    {
        // 视频准备完成后开始播放
        m_Video.Play();
        StartCoroutine(UpdateSlider());  // 启动协程更新滑块
    }

    private IEnumerator UpdateSlider()
    {
        // 在视频播放期间不断更新滑块的值
        while (m_Video.isPlaying)
        {
            // 显式将 double 转换为 float
            progressSlider.value = (float)(m_Video.time / m_Video.length);
            yield return null;
        }
    }

    private void OnSliderValueChanged(float value)
    {
        // 根据滑块的值调整视频的播放进度
        // 显式将 float 转换为 double
        m_Video.time = (double)value * m_Video.length;
    }

    private void OnVideoEnd(VideoPlayer source)
    {
        // 视频播放完成后重新开始播放
        m_Video.time = 0;  // 将视频时间重置到 0
        m_Video.Play();  // 重新播放视频
        progressSlider.value = 0;  // 将滑块重置到最开始的位置
    }
}