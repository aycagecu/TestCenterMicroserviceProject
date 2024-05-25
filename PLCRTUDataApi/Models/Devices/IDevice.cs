namespace PLCRTUDataApi.Models.Devices
{
    public interface IDevice
    {
        void ReadRegisters();
        void WriteRegister(string address,object value);
    }
}
