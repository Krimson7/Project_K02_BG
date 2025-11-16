namespace K02.Core
{
    public class PlayerData
    {
        public ulong PlayerId;
        public string Name;
        public int Money = 1500;
        public int TileIndex = 0;

        public PlayerData(ulong id, string name)
        {
            PlayerId = id;
            Name = name;
        }
    }
}