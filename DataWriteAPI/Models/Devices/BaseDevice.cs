using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataReadApi.Models.Devices
{
    public class BaseDevice : IDevice
    {
        [Key]
        public int Id { get; set; }
        public string ipAddress { get; set; }
        public List<Register> registers { get; set; }
        protected WriteDbContext db;


        public BaseDevice()
        {

        }

        public BaseDevice(string ipAddress, List<Register> registers)
        {
            this.ipAddress = ipAddress;
            this.registers = registers;
        }

        public virtual void ReadRegisters()
        {
            //throw new NotImplementedException();
        }

        public virtual void WriteRegister(string address, object value)
        {
            //throw new NotImplementedException();
        }
    }
}
