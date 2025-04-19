using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPanel : MonoBehaviour
{
    public VideoPlayer m_Video;  // ��Ƶ���������
    public Slider progressSlider;  // ��Ƶ���Ȼ���

    private void OnEnable()
    {
        m_Video.prepareCompleted += OnVideoReady;  // ��Ƶ׼�����ʱ�Ļص�
        m_Video.loopPointReached += OnVideoEnd;  // ��Ƶ�������ʱ�Ļص�
        progressSlider.onValueChanged.AddListener(OnSliderValueChanged);  // ����ֵ�ı�ʱ�Ļص�
    }

    private void OnDisable()
    {
        m_Video.prepareCompleted -= OnVideoReady;
        m_Video.loopPointReached -= OnVideoEnd;
        progressSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

    private void OnVideoReady(VideoPlayer source)
    {
        // ��Ƶ׼����ɺ�ʼ����
        m_Video.Play();
        StartCoroutine(UpdateSlider());  // ����Э�̸��»���
    }

    private IEnumerator UpdateSlider()
    {
        // ����Ƶ�����ڼ䲻�ϸ��»����ֵ
        while (m_Video.isPlaying)
        {
            // ��ʽ�� double ת��Ϊ float
            progressSlider.value = (float)(m_Video.time / m_Video.length);
            yield return null;
        }
    }

    private void OnSliderValueChanged(float value)
    {
        // ���ݻ����ֵ������Ƶ�Ĳ��Ž���
        // ��ʽ�� float ת��Ϊ double
        m_Video.time = (double)value * m_Video.length;
    }

    private void OnVideoEnd(VideoPlayer source)
    {
        // ��Ƶ������ɺ����¿�ʼ����
        m_Video.time = 0;  // ����Ƶʱ�����õ� 0
        m_Video.Play();  // ���²�����Ƶ
        progressSlider.value = 0;  // ���������õ��ʼ��λ��
    }
}