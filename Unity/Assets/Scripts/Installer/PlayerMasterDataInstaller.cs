using UnityEngine;
using Zenject;
using Table.MasterData;

[CreateAssetMenu(fileName = "PlayerMasterDataInstaller", menuName = "Installers/PlayerMasterDataInstaller")]
public class PlayerMasterDataInstaller : ScriptableObjectInstaller<PlayerMasterDataInstaller>
{
    [SerializeField]
    private PlayerRepository repository;

    public override void InstallBindings()
    {
        Container.BindInstance(repository);
    }
}
