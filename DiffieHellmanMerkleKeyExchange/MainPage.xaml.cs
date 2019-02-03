using DiffieHellmanMerkleKeyExchange.Datagram;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiffieHellmanMerkleKeyExchange {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        UdpClient receivingUdpClient = new UdpClient();
        public MainPage() {
            this.InitializeComponent();
            //Task.Factory.StartNew(async () => {
            //    while (true) {
            //        var recieved = await
            //    }
            //});
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {

        }

        private void g_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void p_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private async void Coordinator_Click(object sender, RoutedEventArgs e) {
            if (CanCoordinate(out IPEndPoint peerIPEndpoint)) {
                using (var UdpClient = new UdpClient(new IPEndPoint(IPAddress.IPv6Loopback, peerIPEndpoint.Port))) {
                    var invitation = new InvitationRequest {
                    };
                    MemoryStream stream = new MemoryStream();
                    var json_serializer = new DataContractJsonSerializer(typeof(InvitationRequest));
                    json_serializer.WriteObject(stream, invitation);
                    var bytes = stream.ToArray();
                    await UdpClient.SendAsync(bytes, bytes.Length, peerIPEndpoint);
                }
            }
        }
        private int g;
        private string p;
        private bool CanCoordinate(out IPEndPoint peerIPEndPoint) {
            g = 0;
            p = string.Empty;
            peerIPEndPoint = null;
            var error_message = string.Empty;
            if (int.TryParse(Port.Text, out int PeerPort)) {
                if (IPAddress.TryParse(Peer.Text, out IPAddress peerIPAddress)) {
                    peerIPEndPoint = new IPEndPoint(peerIPAddress, PeerPort);
                }
                else {
                    error_message += string.Format("|Cannot parse IPAddress from Peer IP: {0}|", Peer.Text);
                }
            }
            else {
                error_message += string.Format("|Cannot parse int from Port: {0}|", Port.Text);
            }
            if (!int.TryParse(GeneratingElement.Text, out g)) {
                error_message += string.Format("|Cannot parse int from Generating Element: {0}|", Port.Text);
            }
            for (int i = 0; i < CyclicGroup.Text.Length; i++) {
                if (i > 0) {
                    if (CyclicGroup.Text[i] < '0' ||
                        CyclicGroup.Text[i] > '9') {
                        error_message += string.Format("|CyclicGroup[{0}] => '{1}' must be 0 - 9| ", i, CyclicGroup.Text[i]);
                    }
                }
                else {
                    if (CyclicGroup.Text[i] < '1' ||
                        CyclicGroup.Text[i] > '9') {
                        error_message += string.Format("|CyclicGroup[{0}] => '{1}' must be 1 - 9|", i, CyclicGroup.Text[i]);
                    }
                }
                p = CyclicGroup.Text;
            }
            PeerParseError.Text = error_message;
            return string.IsNullOrEmpty(error_message);
        }
        private bool CanReceiveInvitations(out int port) {
            port = 0;
            return false;
        }
    }
}
