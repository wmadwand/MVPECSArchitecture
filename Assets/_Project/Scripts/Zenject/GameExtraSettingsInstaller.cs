using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameExtraSettingsInstaller", menuName = "Installers/GameExtraSettingsInstaller")]
public class GameExtraSettingsInstaller : ScriptableObjectInstaller<GameExtraSettingsInstaller>
{
    public Player.ExtraSettings playerExtraSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(playerExtraSettings).IfNotBound();
    }
}