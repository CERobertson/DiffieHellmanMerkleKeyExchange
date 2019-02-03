using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace DiffieHellmanMerkleKeyExchangeWPF {
    [DataContract]
    public class Settings : AbstractNotifyPropertyHasChanged {
        public Settings() {
            Invitations = new Invitations();
        }

        protected int generatingElement;
        [DataMember]
        public int GeneratingElement {
            get { return generatingElement; }
            set {
                generatingElement = value;
                NotifyPropertyChanged();
            }
        }
        protected string cyclicGroup;
        [DataMember]
        public string CyclicGroup {
            get { return cyclicGroup; }
            set {
                cyclicGroup = value;
                NotifyPropertyChanged();
            }
        }
        protected string peerIP;
        [DataMember]
        public string PeerIP {
            get { return peerIP; }
            set {
                peerIP = value;
                NotifyPropertyChanged();
            }
        }
        protected int peerPort;
        [DataMember]
        public int PeerPort {
            get { return peerPort; }
            set {
                peerPort = value;
                NotifyPropertyChanged();
            }
        }
        protected int invitationsPort;
        [DataMember]
        public int InvitationsPort {
            get { return invitationsPort; }
            set {
                invitationsPort = value;
                NotifyPropertyChanged();
            }
        }
        protected int conversationPort;
        [DataMember]
        public int ConversationPort {
            get { return conversationPort; }
            set {
                conversationPort = value;
                NotifyPropertyChanged();
            }
        }
        protected string message;
        [DataMember]
        public string Message {
            get { return message; }
            set {
                message = value;
                NotifyPropertyChanged();
            }
        }
        protected Invitation selectedInvitation;
        [DataMember]
        public Invitation SelectedInvitation {
            get { return selectedInvitation; }
            set {
                selectedInvitation = value;
                NotifyPropertyChanged();
            }
        }
        protected Invitations invitations;
        [DataMember]
        public Invitations Invitations {
            get { return invitations; }
            set {
                invitations = value;
                NotifyPropertyChanged();
            }
        }
    }
}
