using cfg;
using JKFrame;
using UnityEngine;

public static class BubbleDataToType
{
    public static BubbleBase DataToType(BubbleData data)
    {
        if (data == null) return null;
        BubbleBase bubble = null;
        switch (data.type)
        {
            case BubbleType.NormalBubble :
                bubble = ResSystem.InstantiateGameObject<NormalBubble>(nameof(NormalBubble));
                break;
            case BubbleType.PoppingBubble :
                bubble = ResSystem.InstantiateGameObject<PoppingBubble>(nameof(PoppingBubble));
                break;
        }
        if (bubble == null) return null;
        
        bubble.SetData(data);

        return bubble;
    }
}
