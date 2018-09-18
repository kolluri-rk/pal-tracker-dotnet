namespace PalTracker
{
    public class CloudFoundryInfo
    {
        public string Port { get; private set; }
        public string MemoryLimit { get; private set; }
        public string CfInstanceIndex { get; private set; }
        public string CfInstanceAddr { get; private set; }

        public CloudFoundryInfo(string port, string memoryLimit, string cfInstanceIndex, string cfInstanceAddr)
        {
            Port = port;
            MemoryLimit = memoryLimit;
            CfInstanceIndex = cfInstanceIndex;
            CfInstanceAddr = cfInstanceAddr;
        }
    }
}