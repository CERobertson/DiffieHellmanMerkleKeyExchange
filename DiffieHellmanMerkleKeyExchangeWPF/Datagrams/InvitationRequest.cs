using System;

namespace DiffieHellmanMerkleKeyExchangeWPF.Datagrams {
    [Serializable]
    public class InvitationRequest {
        public int GeneratingElement;
        public string CyclicGroup;
        public string PublicKey;
    }
}
