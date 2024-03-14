using Appsulove.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    public int score;
    public float distance;

    public UserData(int score, float distance)
    {
        this.score = score;
        this.distance = distance;
    }
}

public class UserDataStorage
{
    private const string UserDataKey = "UserDataStorageKey";
    private readonly PrefsStorage _prefsStorage;

    //TODO: inject
    public UserDataStorage()
    {
        _prefsStorage = new PrefsStorage();
    }

    public void Save(UserData data)
    {
        _prefsStorage.Serialize(UserDataKey, data);
    }

    public UserData Load()
    {
        return _prefsStorage.Deserialize<UserData>(UserDataKey);
    }
}
