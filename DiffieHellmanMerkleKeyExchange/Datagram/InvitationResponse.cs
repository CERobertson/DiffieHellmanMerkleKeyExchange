using System.Runtime.Serialization;

namespace DiffieHellmanMerkleKeyExchange.Datagram {
    [DataContract]
    public class InvitationResponse {
        [DataMember]
        public string PublicKey;
    }
}
