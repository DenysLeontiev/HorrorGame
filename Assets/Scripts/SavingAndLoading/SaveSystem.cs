using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
    private static string path = Application.persistentDataPath + "playerData.txt";

    public static void Save(PlayerHealth playerHealth)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);

        PlayerDataToSave playerDataToSave = new PlayerDataToSave(playerHealth);

        binaryFormatter.Serialize(fileStream, playerDataToSave);
    }

    public static PlayerDataToSave Load()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        if(File.Exists(path))
        {
            using FileStream fileStream = new FileStream(path,FileMode.Open);

            PlayerDataToSave playerDataToReturn = binaryFormatter.Deserialize(fileStream) as PlayerDataToSave;

            return playerDataToReturn;
        }
        else
        {
            Debug.LogError($"File with path:  \"{path} \" does not exists");
            return null;
        }
    }
}
