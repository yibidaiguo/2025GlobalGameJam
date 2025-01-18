using JKFrame;
using UnityEngine;

[CreateAssetMenu(fileName = "BubbleConfig", menuName = "配置/泡泡配置")]
public class BubbleConfig : ConfigBase
{
    [Header("泡泡文字显示间隔时间")]
    public float contentTransitionTime;
    [Header("普通泡泡存活时间")]
    public float normalBubbleLifeTime;
    [Header("可戳破泡泡存活时间")]
    public float poppingBubbleLifeTime;
}
