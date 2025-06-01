using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogParticleScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem forParticleSystem;
    private float destroyPositionZ = 137.1094f; // パーティクルを消去するX座標

    void Start()
    {
        // Particle Systemを取得
        if (forParticleSystem == null)
            forParticleSystem = GetComponent<ParticleSystem>();

        // Particle Systemがなければエラーを出力してスクリプトを停止
        if (forParticleSystem == null)
        {
            Debug.LogError("Particle System is not assigned or found!");
            enabled = false; // スクリプトを無効にする
            return;
        }
    }

    void Update()
    {
        // パーティクルを生成しているか確認
        if (forParticleSystem.isPlaying)
        {
            
            // パーティクルの位置をチェックし、指定した位置を超えたら停止させる
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[forParticleSystem.particleCount];
            int numParticlesAlive = forParticleSystem.GetParticles(particles);
            for (int i = 0; i < numParticlesAlive; i++)
            {
                Vector3 worldPosition = transform.TransformPoint(particles[i].position);
                float worldZ = worldPosition.z;
                // パーティクルの位置が指定した位置を超えた場合
                if (worldZ > destroyPositionZ)
                {
                    // パーティクルを停止
                    particles[i].remainingLifetime = 0;
                }
            }
            // 修正したパーティクル情報を再適用
            forParticleSystem.SetParticles(particles, numParticlesAlive);
        }
    }
}
