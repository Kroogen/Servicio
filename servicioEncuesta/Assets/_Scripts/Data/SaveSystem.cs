using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static int elemento = LoadControl();
    
    public static void SavePlayer(Player player, string []resultados, string resultado)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + Constantes.SAVE_PLAYER + elemento + Constantes.SAVE_EXTENSION;
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player, resultados, resultado);
        
        formatter.Serialize(stream, data);
        
        stream.Close();
        SaveControl();
    }

    public static PlayerData LoadPlayer(int i)
    {
        string path = Application.persistentDataPath + Constantes.SAVE_PLAYER + i + Constantes.SAVE_EXTENSION;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            
            return data;
        }
        return null;

    }

    public static void SaveControl()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + Constantes.SAVE_CONTROL;
        FileStream stream = new FileStream(path, FileMode.Create);

        Control data = new Control();
        data.total = ++elemento;
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static int LoadControl()
    {
        string path = Application.persistentDataPath + "/control.bin";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Control data = formatter.Deserialize(stream) as Control;
            stream.Close();
            
            return data.total;
        }
        Debug.Log("No existe el archivo");
        return 0;

    }

    public static void BorraMemoria()
    {
        string path;
        for (int i = 0; i < LoadControl(); i++)
        {
            path = Application.persistentDataPath + "/player" + i + ".bin";
            File.Delete(path);
        }
        
        path = Application.persistentDataPath + "/control.bin";
        File.Delete(path);
        Debug.Log("Borrado: ");
    }

    public static Configuracion LoadConfiguracion()
    {
        string path = Application.persistentDataPath + "/Configuracion.bin";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Configuracion data = formatter.Deserialize(stream) as Configuracion;
            stream.Close();
            return data;
        }
        Debug.Log("No existe el archivo");
        return null;
    }
    
    public static void SaveConfiguracion(Configuracion config)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Configuracion.bin";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        
        formatter.Serialize(stream, config);
        
        stream.Close();
    }
    
}
