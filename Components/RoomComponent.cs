namespace GameExplorer.Components
{
    public partial class RoomComponent : UserControl
    {
        public string RoomName { get; set; }
        public int PlayerCount { get; set; }
        public GameType GameType { get; set; }

        public RoomComponent(string roomName, GameType gameType, int playerCount)
        {
            {
                InitializeComponent();
                this.RoomName = roomName;
                this.PlayerCount = playerCount;
                this.GameType = gameType;
                roomNameLabel.Text = roomName;
                playersCountLabel.Text = $"Player Count: {playerCount}";
                gameTypeLabel.Text = $"Game Type: {gameType.ToString()}";
                if (!(PlayerCount < 2))
                {
                    joinBtn.Enabled = false;
                }
            }
        }
    }
}