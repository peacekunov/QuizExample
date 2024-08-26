using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    public Level LevelPrefab;

    public Question QuestionPrefab;

    public override void InstallBindings()
    {
        Container.Bind<PlayerState>().AsSingle();
        Container.Bind<PlayerData>().AsSingle();
        Container.Bind<Storage<PlayerData>>().To<PlayerPrefsStorage<PlayerData>>()
            .AsSingle().WithArguments(Constants.PLAYER_DATA_STORAGE_KEY);
        Container.Bind<Questions>().AsSingle();

        Container.Bind<AssetLoader<TextAsset>>().To<LocalAssetLoader<TextAsset>>().AsCached();
        Container.Bind<AssetLoader<Sprite>>().To<LocalAssetLoader<Sprite>>().AsCached();

        Container.BindFactory<Level, Level.Factory>().FromComponentInNewPrefab(LevelPrefab);
        Container.BindFactory<int, Question, Question.Factory>().FromComponentInNewPrefab(QuestionPrefab);
        Container.Bind<QuestionModel>().AsTransient();
    }
}