using System.Runtime.Serialization;

namespace DiffieHellmanMerkleKeyExchange.Datagram {
    [DataContract]
    public class InvitationRequest
    {
        [DataMember]
        public int GeneratingElement;
        [DataMember]
        public string CyclicGroup;
        [DataMember]
        public string PublicKey;
    }
}
