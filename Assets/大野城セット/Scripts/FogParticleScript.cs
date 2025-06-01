using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogParticleScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem forParticleSystem;
    private float destroyPositionZ = 137.1094f; // �p�[�e�B�N������������X���W

    void Start()
    {
        // Particle System���擾
        if (forParticleSystem == null)
            forParticleSystem = GetComponent<ParticleSystem>();

        // Particle System���Ȃ���΃G���[���o�͂��ăX�N���v�g���~
        if (forParticleSystem == null)
        {
            Debug.LogError("Particle System is not assigned or found!");
            enabled = false; // �X�N���v�g�𖳌��ɂ���
            return;
        }
    }

    void Update()
    {
        // �p�[�e�B�N���𐶐����Ă��邩�m�F
        if (forParticleSystem.isPlaying)
        {
            
            // �p�[�e�B�N���̈ʒu���`�F�b�N���A�w�肵���ʒu�𒴂������~������
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[forParticleSystem.particleCount];
            int numParticlesAlive = forParticleSystem.GetParticles(particles);
            for (int i = 0; i < numParticlesAlive; i++)
            {
                Vector3 worldPosition = transform.TransformPoint(particles[i].position);
                float worldZ = worldPosition.z;
                // �p�[�e�B�N���̈ʒu���w�肵���ʒu�𒴂����ꍇ
                if (worldZ > destroyPositionZ)
                {
                    // �p�[�e�B�N�����~
                    particles[i].remainingLifetime = 0;
                }
            }
            // �C�������p�[�e�B�N�������ēK�p
            forParticleSystem.SetParticles(particles, numParticlesAlive);
        }
    }
}
