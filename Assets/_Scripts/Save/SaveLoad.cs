using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad : MonoBehaviour 
{
    public static SaveLoad save;
    void Awake()
    {
        save = this;
    }
	
    public void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Create(Application.persistentDataPath + "/Secret.DickPics");

        SaveManager saver = new SaveManager();
        
        saver.maxStamina = Stamina.stam.maxStamina;
        saver.maxHealth = PlayerHealth.health.maxHealth;
        saver.points = Score.score.nPoints;
        saver.level = PlayerStates.playerStates.level;

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        saver.savePosition = new SavePosition(player.position);

        binary.Serialize(fStream, saver);
        fStream.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath+ "/Secret.DickPics"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/Secret.DickPics", FileMode.Open);
            SaveManager saver = (SaveManager)binary.Deserialize(fStream);
            fStream.Close();

            Stamina.stam.maxStamina = saver.maxStamina;
            PlayerHealth.health.maxHealth = saver.maxHealth;
            Score.score.nPoints = saver.points;
            Vector3 newPosition = saver.savePosition.GetPositionAsVector3();
            GameObject.FindGameObjectWithTag("Player").transform.position = newPosition;
            PlayerStates.playerStates.level = saver.level;
        }
    }
}

[Serializable]
class SaveManager
{
    public float maxStamina;
    public float maxHealth;
    public float points;
    public SavePosition savePosition;
    public float level;
}
    
[Serializable]
class SavePosition
{
    private float x;
    private float y;
    private float z;

    public SavePosition(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public SavePosition(Vector3 position)
    {
        this.x = position.x;
        this.y = position.y;
        this.z = position.z;
    }
   
    public Vector3 GetPositionAsVector3() 
    {
        return new Vector3(x, y, z);
    }
}