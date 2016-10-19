
namespace App.Common.Data
{
    public class KeyNamePair
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public KeyNamePair(int key, string name)
        {
            this.Key = key;
            this.Name = name;
        }
    }
}
