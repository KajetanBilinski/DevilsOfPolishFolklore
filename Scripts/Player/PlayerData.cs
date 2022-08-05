namespace Player
{
    public class PlayerData
    {
        private static PlayerData _instance;

        public int money;
        
        public static PlayerData instance
        {
            get
            {
                if(PlayerData._instance == null)
                {
                    PlayerData._instance = new PlayerData();
                }
                return PlayerData._instance;
            }
            set => PlayerData._instance = value;
        }
        protected PlayerData() => this.SetupNewPlayerData();
        
        private void SetupNewPlayerData()
        {
            this.money = 0;
        }
        
        public void AddMoney(int amount) => this.money += amount;
        public void ReduceMoney(int amount) => this.money -= amount;
    }
}