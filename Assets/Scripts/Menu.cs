using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdpKit;
using Photon.Bolt;
using Photon.Bolt.Matchmaking;
using UdpKit;

public class Menu : GlobalEventListener
{
    
    public void createServer()
    {
        BoltLauncher.StartServer();
    }

	public override void BoltStartDone()
	{
		BoltMatchmaking.CreateSession(sessionID: "test", sceneToLoad: "Game");
		
	}

	public void joinServer()
    {
        BoltLauncher.StartClient();
    }

    public override void SessionListUpdated(Map<System.Guid, UdpSession> sessionList)
    {
        Debug.LogFormat("Session list updated: {0} total sessions", sessionList.Count);

        foreach (var session in sessionList)
        {
            UdpSession photonSession = session.Value as UdpSession;

            if (photonSession.Source == UdpSessionSource.Photon)
            {
                BoltMatchmaking.JoinSession(photonSession);
            }
        }
    }

}
