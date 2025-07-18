using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// �������� ���� �� ���⸦ ������ �� ���Ǵ� ����, ��ƼŬ ���� Ŭ����
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
