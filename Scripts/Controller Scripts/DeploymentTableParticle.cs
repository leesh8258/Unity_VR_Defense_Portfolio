using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// 스테이지 입장 전 무기를 선택할 때 사용되는 사운드, 파티클 시작 클래스
/// </summary>
public class DeploymentTableParticle : XRSocketInteractor
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        this.GetComponent<AudioSource>().Play();
        transform.GetComponentInChildren<ParticleSystem>().Play();
        
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        transform.GetComponentInChildren<ParticleSystem>().Stop();

    }
}
