namespace DiffieHellmanMerkleKeyExchangeWPF {
    using System;
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;

    [DataContract]
    public class Invitations
    {
        public Invitations() {
            Requested = new ObservableCollection<Invitation>();
            Pending = new ObservableCollection<Invitation>();
            Accepted = new ObservableCollection<Invitation>();
            Rejected = new ObservableCollection<Invitation>();
            Blocked = new ObservableCollection<Invitation>();
        }

        [DataMember]
        public ObservableCollection<Invitation> Requested { get; set; }
        [DataMember]
        public ObservableCollection<Invitation> Pending { get; set; }
        [DataMember]
        public ObservableCollection<Invitation> Accepted { get; set; }
        [DataMember]
        public ObservableCollection<Invitation> Rejected { get; set; }
        [DataMember]
        public ObservableCollection<Invitation> Blocked { get; set; }

    }
}
