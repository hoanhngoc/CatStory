using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Unity.VisualScripting;

public class FileDataHandler
{
    private string dataDirPath = "";

    private string dataFilename = "";

    private bool useEncryption =false;

    private readonly string encryptionCodeWord = "word";
    public FileDataHandler(string dataDirPath, string dataFilename, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFilename = dataFilename;
        this.useEncryption = useEncryption;
        
    }
    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFilename);
        GameData loadedData =null;
        if(File.Exists(fullPath))
        {
            try
            {
                string dataToload = " ";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToload = reader.ReadToEnd();
                    }
                }
                if(useEncryption)
                {
                    dataToload= EncryptDecrypt(dataToload);
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToload);

            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file:" + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFilename);
        try
        {
            Directory.CreateDirectory(Path.GetFileName(fullPath));
            
            string dataToStore = JsonUtility.ToJson(data,true);

            if(useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }
            using (FileStream stream = new FileStream(fullPath, FileMode.Create)) 
            {
                 using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);   
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("Error occured when trying to save data to File:" + fullPath + "\n" + e);
        }
    }

    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionCodeWord[i%encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
}
