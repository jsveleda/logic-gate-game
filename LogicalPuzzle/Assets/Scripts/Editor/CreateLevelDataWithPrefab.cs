using UnityEditor;
using UnityEngine;

public class CreateLevelDataWithPrefab
{
    [MenuItem("Assets/Create Level Data With Prefab", true)]
    private static bool ValidateCreateLevelDataWithPrefab()
    {
        // Verifica se o objeto selecionado é um prefab
        return Selection.activeObject is GameObject;
    }

    [MenuItem("Assets/Create Level Data With Prefab")]
    private static void Create()
    {
        // Obtém o prefab selecionado
        GameObject selectedPrefab = Selection.activeObject as GameObject;

        // Cria a instância do ScriptableObject
        LevelData asset = ScriptableObject.CreateInstance<LevelData>();

        // Atribui o prefab selecionado ao campo levelPrefab
        asset.levelPrefab = selectedPrefab;

        // Cria o asset no projeto
        string prefabName = selectedPrefab.name.Replace(" ", "");
        string path = AssetDatabase.GetAssetPath(selectedPrefab);
        path = System.IO.Path.GetDirectoryName(path) + "/" + prefabName + "Data.asset";
        AssetDatabase.CreateAsset(asset, path);
        AssetDatabase.SaveAssets();

        // Seleciona o asset criado na janela do projeto
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
