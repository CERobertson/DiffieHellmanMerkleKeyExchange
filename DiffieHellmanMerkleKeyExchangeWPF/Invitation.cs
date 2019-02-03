using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DiffieHellmanMerkleKeyExchangeWPF
{
    [DataContract]
    public class Invitation : AbstractNotifyPropertyHasChanged {
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
        protected string publicKey;
        [DataMember]
        public string PublicKey{
            get { return publicKey; }
            set {
                publicKey = value;
                NotifyPropertyChanged();
            }
        }
    }
}
