using UnityEditor;
using UnityEngine;

public class YooConfigEditor : MonoBehaviour
{

    [MenuItem("工具/设置/YooConfig")]
    static void EditYooConfig()
    {
        // 查找名为 "YooConfig.asset" 的文件
        string[] assetPaths = AssetDatabase.FindAssets("t:ScriptableObject YooConfig");
        if (assetPaths.Length > 0)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(assetPaths[0]);
            Object asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
            Selection.activeObject = asset;
        }
        else
        {
            Debug.LogWarning("YooConfig.asset not found.");
        }
    }
}