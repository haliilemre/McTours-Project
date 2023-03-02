namespace McTours
{
    [Flags]
    public enum Utility
    {
        None = 0,
        FoodService = 1,
        Wifi = 2,
        PowerOutlet = 4,
        UsbCharge = 8,
        Tv = 16,
        Radio = 32,
        Headset = 64,
        Toilet = 128,
    }
}
