using System;
using UnityEngine;

[Serializable]

public class SaveData
{
    public int levelIndex;
    //more data to be added, probably

    public SaveData(int levelIndex)
    {
        this.levelIndex = levelIndex;
    }
}

//[Serializable]
//public class SerializableVector2
//{
//    public float x;
//    public float y;

//    public SerializableVector2(float x, float y)
//    {
//        this.x = x;
//        this.y = y;
//    }

//    public SerializableVector2(Vector2 v)
//    {
//        this.x = v.x;
//        this.y = v.y;
//    }

//    public static implicit operator Vector2(SerializableVector2 sv)
//    {
//        return new Vector2(sv.x, sv.y);
//    }

//    public static implicit operator SerializableVector2(Vector2 v)
//    {
//        return new SerializableVector2(v.x, v.y);
//    }
//    //implicit conversions for convenience

//}
