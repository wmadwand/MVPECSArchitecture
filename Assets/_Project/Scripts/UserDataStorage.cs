using Appsulove.Utils;

public class UserDataStorage
{
    private const string UserDataKey = "UserDataStorageKey";
    private readonly PrefsStorage _prefsStorage;

    public UserDataStorage()
    {
        //TODO: inject
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
