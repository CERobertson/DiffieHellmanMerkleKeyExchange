namespace DiffieHellmanMerkleKeyExchangeWPF {
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.Serialization.Json;
    using System.Threading.Tasks;
    using System.Numerics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Text;

    public partial class MainPage : Page {
        Random random = new Random();
        public MainPage() {
            this.InitializeComponent();
        }
        public Settings Settings {
            get { return DataContext as Settings; }
            set { DataContext = value; }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            if (Settings == null) {
                Settings = new Settings {
                    GeneratingElement = 2,
                    CyclicGroup = ParseCyclicGroup("115045358815588507102615624450272010112370228380439530897870477607726414709505659620889659048104803649825095229270762943255797304638368170419317671789217789560355068887818369290126701770021989378904688750834275421899202770311644890795041359878456249568468584932800071900845617574217773795695378506267233408763736516207353129819266210078442617385576800957345585142391734947382760492203822334054982142151377645689743397798709559551910560464029590188452692555402513756398344183464414934615147515360641260836541732199435376661009516177100388352254642277814968196620048008567550743347443809195591151147516379124004580834294671212595506383799271593323837604583006390299938150780289739155927486735554805512633282114357028420328046774309005190598393649448470053012084476943591553891048330897056510504817889143211285944012684732547093778287608191109299544372143033397060681593201744006953440124293204606252763567504219849277930866973620135235141957655086329818224707295526212724158993556645945754237009747425755860698728119804286401702917453068607878007590575327513519831238220044359940046671407069317928977311839344243901236746464510796033221440216960614645529198587953521357843256076108814238844058107896027318524295519649301257681370733725581567597688321863668236090092333699287807394003501927022795957153063259028681505064557044948501765972418809532998937248692735387665547022525366629144233769551933047334127496116899882191590605990946364268796264636748554997778208542815572080518581384719965689226318687287493"),
                    InvitationsPort = 32124,
                    ConversationPort = 32125,
                    PeerIP = "::1",
                    PeerPort = 32124
                };
            }
        }

        private void PeerInvite_Click(object sender, RoutedEventArgs e) {
            a_secret = random.Next();
            var invitation = new Invitation {
                GeneratingElement = Settings.GeneratingElement,
                CyclicGroup = Settings.CyclicGroup,
                PublicKey = GeneratePublicKey(Settings.GeneratingElement, a_secret, Settings.CyclicGroup)
            };
            Settings.Invitations.Accepted.Add(invitation);
        }

        private string GeneratePublicKey(int generating_element, int secret, string cyclic_group) {
            return BigInteger.ModPow(new BigInteger(generating_element), secret, BigInteger.Parse(cyclic_group)).ToString();
        }
        private string GenerateSecret(string public_key, int secret, string cyclic_group) {
            return BigInteger.ModPow(BigInteger.Parse(public_key), secret, BigInteger.Parse(cyclic_group)).ToString();
        }

        private int a_secret;
        private void Conversations_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var i = e.AddedItems[0] as Invitation;
            string a_public = i.PublicKey;
            int b_secret = random.Next();
            string b_public = GeneratePublicKey(i.GeneratingElement, b_secret, i.CyclicGroup);
            string secret_by_a = GenerateSecret(b_public, a_secret, i.CyclicGroup);
            string secret_by_b = GenerateSecret(a_public, b_secret, i.CyclicGroup);
            var success = string.Compare(secret_by_a, secret_by_b) == 0;
        }
        private string ParseCyclicGroup(string input) {
            for (int i = 0; i < input.Length; i++) {
                if (i > 0) {
                    if (input[i] < '0' ||
                        input[i] > '9') {
                        throw new Exception(string.Format("|CyclicGroup[{0}] => '{1}' must be 0 - 9| ", i, input[i]));
                    }
                }
                else {
                    if (input[i] < '1' ||
                        input[i] > '9') {
                        throw new Exception(string.Format("|CyclicGroup[{0}] => '{1}' must be 1 - 9|", i, input[i]));
                    }
                }
            }
            return input;
        }

    }
}
