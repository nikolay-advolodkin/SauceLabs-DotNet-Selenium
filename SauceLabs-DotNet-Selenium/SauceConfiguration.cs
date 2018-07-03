namespace SauceLabsDotNetSelenium
{
    internal class SauceConfiguration
    {
        public string Browser { get; set; }
        public string Version { get; set; }
        public string OS { get; set; }
        public string DeviceName { get; set; }
        public string DeviceOrientation { get; set; }
        public object TestCaseName { get; set; }
    }
}