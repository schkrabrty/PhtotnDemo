using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using TMPro;

public class XRSimpleNetworkInteractable : XRSimpleInteractable
{
    private PhotonView PV;
    private Color color;
    public TMP_Text txtInfo;
    public GameObject ParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem.SetActive(false);
        color = this.gameObject.GetComponent<MeshRenderer>().material.color;
        PV = this.GetComponent<PhotonView>();
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        PV.RequestOwnership();

        if (PV.IsMine) // If the photon view component that I am interacting with, is owned by me
        {
            ParticleSystem.SetActive(true);
        }

        PV.RPC("DuringHovering", RpcTarget.AllBuffered);

        base.OnHoverEntered(args);
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        PV.RequestOwnership();

        if (PV.IsMine) // If the photon view component that I am interacting with, is owned by me
        {
            ParticleSystem.SetActive(false);
        }

        PV.RPC("AfterHovering", RpcTarget.AllBuffered);

        base.OnHoverExited(args);
    }

    [PunRPC]
    public void DuringHovering()
    {
        txtInfo.text = "";
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
    }

    [PunRPC]
    public void AfterHovering()
    {
        txtInfo.text = "Touch me!";
        this.gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
}
