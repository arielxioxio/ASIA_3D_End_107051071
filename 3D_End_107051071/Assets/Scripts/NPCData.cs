using UnityEngine;


[CreateAssetMenu(fileName ="NPC 資料",menuName ="AYA/NPC資料")]
public class NPCData : ScriptableObject
{
    [Header("第一段對話"),TextArea(1,5)]
    public string dialougA;
    [Header("第二段對話"),TextArea(1,5)]
    public string dialougB;
    [Header("第三段對話"),TextArea(1,5)]
    public string dialougC;
    [Header("任務需求")]
    public int count;
    [Header("已取得數量")]
    public int countCurrent;

}
