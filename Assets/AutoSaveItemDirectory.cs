using BayatGames.SaveGameFree;
using UnityEngine;

using BayatGames.SaveGameFree.Encoders;
using BayatGames.SaveGameFree.Serializers;
using BayatGames.SaveGameFree.Types;
using System.Text;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class ItemDirectory
{
    public string Title;
    public List<string> items;
}

//[RequireComponent(typeof(CellUnit))]
public class AutoSaveItemDirectory : AutoSaveSystem<ItemDirectory>
{

    [Header("Cell")]
    [Space]

    public ItemTable listForDecode;

    void Start()
    {

        //update
        foreach (var cell in GetComponentsInChildren<CellUnit>().Select((alphabet, index) => new { Value = alphabet, Index = index }))
        {
            Debug.LogFormat("{0} => {1}", cell.Index, cell.Value);
            cell.Value.OnChanged += item =>
            {
                if (item == null) customData.items[cell.Index] = "";
                else customData.items[cell.Index] = item.status.Name;
            };
        }

        if(loadOnStart)
        {
            Load();

            Debug.LogFormat("OOOOOOOO :::: {0}", customData);
            if (customData != null)
            {
                foreach (var cell in GetComponentsInChildren<CellUnit>().Select((alphabet, index) => new { Value = alphabet, Index = index }))
                {
                    Debug.LogFormat("{0} => {1}", cell.Index, cell.Value);

                    //DOTO:item ItemTable -> DropItem -> Inventory CellUnit
                    cell.Value.AddItem(
                        listForDecode.GetItemByName(customData.items[cell.Index])
                        );
                }
            }

        }

        //CellUnit cell = GetComponent<CellUnit>();
        //cell.OnChanged += item =>
        //{
        //    if (item == null) customData = null;
        //    else customData = item.status.Name;
        //};

        //if (loadOnStart)
        //{
        //    Load();
        //    Debug.LogFormat("{0}", customData);
        //    if (customData != "")
        //    {
        //        //DOTO:item ItemTable -> DropItem -> Inventory CellUnit
        //        cell.gameObject.GetComponent<DragAndDropCell>()
        //            .AddItem(listForDecode.GetItemByName(customData).Item());
        //    }
        //}

        if (saveOnStart)
        {
            Save();
        }
    }
}


public class AutoSaveSystem<T> : MonoBehaviour
{
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

    public void Save()
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

    public void Load()
    {
        customData = SaveGame.Load(
            identifier,
            customData,
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