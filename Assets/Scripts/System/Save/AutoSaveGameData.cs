using BayatGames.SaveGameFree;
using UnityEngine;

using BayatGames.SaveGameFree.Encoders;
using BayatGames.SaveGameFree.Serializers;
using System.Text;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public Dictionary<string, ItemDirectory> directories;
    public int money;

    public GameData()
    {
        directories = new Dictionary<string, ItemDirectory>();
        money = 0;
    }
}


public class AutoSaveGameData : AutoSaveSystem<GameData>
{
    public delegate void EventHandler(GameData data);
    public event EventHandler OnSaveBefore, OnSaveAfter, OnLoadBefore, OnLoadAfter;
    
    public override void Save()
    {
        OnSaveBefore?.Invoke(customData);
        base.Save();
        OnSaveAfter?.Invoke(customData);
    }

    public override void Load()
    {
        OnLoadBefore?.Invoke(customData);
        base.Load();
        Debug.Log("GOOOOOOOOOOLD???");
        OnLoadAfter?.Invoke(customData);
    }
}


public class AutoSaveSystem<T> : MonoBehaviour
{
    /// <summary>
    /// Save format.
    /// </summary>
    public enum SaveFormat
    {

        /// <summary>
        /// The XML.
        /// </summary>
        XML,

        /// <summary>
        /// The JSON.
        /// </summary>
        JSON,

        /// <summary>
        /// The Ninary.
        /// </summary>
        Binary

    }

    public T customData;
    public string identifier = "exampleSaveCustom";

    [Header("Settings")]
    [Space]

    [Tooltip("Encode the data?")]
    /// <summary>
    /// The encode.
    /// </summary>
    public bool encode = false;

    [Tooltip("If you leave it blank this will reset to it's default value.")]
    /// <summary>
    /// The encode password.
    /// </summary>
    public string encodePassword = "";

    [Tooltip("Which serialization format?")]
    public SaveFormat format = SaveFormat.JSON;

    [Tooltip("If you leave it blank this will reset to it's default value.")]
    /// <summary>
    /// The serializer.
    /// </summary>
    public ISaveGameSerializer serializer;

    [Tooltip("If you leave it blank this will reset to it's default value.")]
    /// <summary>
    /// The encoder.
    /// </summary>
    public ISaveGameEncoder encoder;

    [Tooltip("If you leave it blank this will reset to it's default value.")]
    /// <summary>
    /// The encoding.
    /// </summary>
    public Encoding encoding;

    [Tooltip("Where to save? (PersistentDataPath highly recommended).")]
    /// <summary>
    /// The save path.
    /// </summary>
    public SaveGamePath savePath = SaveGamePath.PersistentDataPath;

    [Tooltip("Reset the empty fields to their default value.")]
    /// <summary>
    /// The reset blanks.
    /// </summary>
    public bool resetBlanks = true;


    [Header("Save Events")]
    [Space]


    [Tooltip("Save on Awake()")]
    /// <summary>
    /// The save on awake.
    /// </summary>
    public bool saveOnAwake;

    [Tooltip("Save on Start()")]
    /// <summary>
    /// The save on start.
    /// </summary>
    public bool saveOnStart;

    [Tooltip("Save on OnEnable()")]
    /// <summary>
    /// The save on enable.
    /// </summary>
    public bool saveOnEnable;

    [Tooltip("Save on OnDisable()")]
    /// <summary>
    /// The save on disable.
    /// </summary>
    public bool saveOnDisable = true;

    [Tooltip("Save on OnApplicationQuit()")]
    /// <summary>
    /// The save on application quit.
    /// </summary>
    public bool saveOnApplicationQuit = true;

    [Tooltip("Save on OnApplicationPause()")]
    /// <summary>
    /// The save on application pause.
    /// </summary>
    public bool saveOnApplicationPause;


    [Header("Load Events")]
    [Space]


    [Tooltip("Load on Awake()")]
    /// <summary>
    /// The load on awake.
    /// </summary>
    public bool loadOnAwake;

    [Tooltip("Load on Start()")]
    /// <summary>
    /// The load on start.
    /// </summary>
    public bool loadOnStart = true;

    [Tooltip("Load on OnEnable()")]
    /// <summary>
    /// The load on enable.
    /// </summary>
    public bool loadOnEnable = false;


    protected virtual void Awake()
    {
        if (resetBlanks)
        {
            if (string.IsNullOrEmpty(encodePassword))
            {
                encodePassword = SaveGame.EncodePassword;
            }
            if (serializer == null)
            {
                serializer = SaveGame.Serializer;
            }
            if (encoder == null)
            {
                encoder = SaveGame.Encoder;
            }
            if (encoding == null)
            {
                encoding = SaveGame.DefaultEncoding;
            }
        }
        switch (format)
        {
            case SaveFormat.Binary:
                serializer = new SaveGameBinarySerializer();
                break;
            case SaveFormat.JSON:
                serializer = new SaveGameJsonSerializer();
                break;
            case SaveFormat.XML:
                serializer = new SaveGameXmlSerializer();
                break;
        }
        if (loadOnAwake)
        {
            Load();
        }
        if (saveOnAwake)
        {
            Save();
        }
    }

    void Start()
    {
        if (loadOnStart)
        {
            Load();
        }

        if (saveOnStart)
        {
            Save();
        }
    }

    public virtual void Save()
    {
        SaveGame.Save(
            identifier,
            customData,
            encode,
            encodePassword,
            serializer,
            encoder,
            encoding,
            savePath);
    }

    public virtual void Load()
    {
        customData = SaveGame.Load(
            identifier,
            default(T),
            encode,
            encodePassword,
            serializer,
            encoder,
            encoding,
            savePath);
    }

    protected virtual void OnEnable()
    {
        if (loadOnEnable)
        {
            Load();
        }
        if (saveOnEnable)
        {
            Save();
        }
    }

    protected virtual void OnDisable()
    {
        if (saveOnDisable)
        {
            Save();
        }
    }

    protected virtual void OnApplicationQuit()
    {
        if (saveOnApplicationQuit)
        {
            Save();
        }
    }

    protected virtual void OnApplicationPause()
    {
        if (saveOnApplicationPause)
        {
            Save();
        }
    }
}
