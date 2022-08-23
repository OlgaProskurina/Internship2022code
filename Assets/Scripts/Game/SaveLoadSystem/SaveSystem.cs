using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveSystem
{

    

    public static void SaveScore(string levelName, int lastScore, int hightScore)
    {
        var formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + "/" + levelName.ToString() + ".highscore";
        
        var createFileStream = new FileStream(path, FileMode.Create);



       // formatter.Serialize(createFileStream, score);
    }


    //public static int LoadHighScore(string levelName)
    //{
    //    var path = Application.persistentDataPath + "/" + levelName.ToString() + ".highscore";
    //    if (File.Exists(path))
    //    {
    //        var formatter = new BinaryFormatter();
    //        var openFileStream = new FileStream(path, FileMode.Open);
    //       // formatter.Deserialize(openFileStream) as ScoreSave;

    //    }

    //}



}
