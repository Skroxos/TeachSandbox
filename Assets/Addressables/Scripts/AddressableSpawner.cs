using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TechSandBox.Addressables.Scripts
{
    public class AddressableSpawner : MonoBehaviour
    {
        [SerializeField] private AssetReference prefabReference1;
        [SerializeField] private AssetReference prefabReference2;


        private GameObject _spawnedInstance;

        private bool _isLoading;
        
        
        public void SpawnPrefab1() => LoadPrefab(prefabReference1);
        public void SpawnPrefab2() => LoadPrefab(prefabReference2);


        private void LoadPrefab(AssetReference assetReference)
        {
            if (_isLoading) return;
            LoadDroneModel(assetReference, this.GetCancellationTokenOnDestroy()).Forget();
        }


        private async UniTaskVoid LoadDroneModel(AssetReference assetReference, CancellationToken token)
        {
            try
            {
                _isLoading = true;

                ReleaseCurrentInstance();

                _spawnedInstance = await assetReference.InstantiateAsync().WithCancellation(token);
            }
            catch (OperationCanceledException)
            {
                Debug.LogWarning("Asset loading was canceled.");
                ReleaseCurrentInstance();
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to load asset: {ex.Message}");
            }
            finally
            {
                _isLoading = false;
            }
        }
        
        public void ReleaseCurrentInstance()
        {
            if (_spawnedInstance == null) return;
            UnityEngine.AddressableAssets.Addressables.ReleaseInstance(_spawnedInstance);
            _spawnedInstance = null;
        }

        private void OnDestroy()
        {
            ReleaseCurrentInstance();
        }
    }
}
