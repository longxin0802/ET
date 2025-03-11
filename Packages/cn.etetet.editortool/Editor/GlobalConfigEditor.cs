using UnityEditor;
using UnityEngine;

public class GlobalConfigEditor : MonoBehaviour
{

    [MenuItem("工具/设置/GlobalConfig")]
    static void EditGlobalConfig()
    {
        // 查找名为 "GlobalConfig.asset" 的文件
        string[] assetPaths = AssetDatabase.FindAssets("t:ScriptableObject GlobalConfig");
        if (assetPaths.Length > 0)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(assetPaths[0]);
            Object asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
            Selection.activeObject = asset;
        }
        else
        {
            Debug.LogWarning("GlobalConfig.asset not found.");
        }
    }
}