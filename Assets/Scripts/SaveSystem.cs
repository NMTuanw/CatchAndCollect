using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private static string path = Application.persistentDataPath + "/character.json";

    public static void SaveCharacter(CharacterStats characterStats)
    {
        string json = JsonUtility.ToJson(characterStats);
        File.WriteAllText(path, json);
    }

    public static CharacterStats LoadCharacter()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log("Loaded JSON: " + json);  // Thêm dòng này để kiểm tra JSON
            return JsonUtility.FromJson<CharacterStats>(json);
        }
        return new CharacterStats();  // Trả về một đối tượng mới nếu không có file lưu trữ
    }
}
