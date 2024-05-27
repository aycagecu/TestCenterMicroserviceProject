using DataWebApi.Models.Devices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataWebApi.Models
{
    public class BaseProcess
    {
        [Key]
        public int Id {  get; set; }
        public List<BaseDevice> devices {  get; set; }
        private int deviceCount {  get; set; }

        [ForeignKey("TestCenter")]
        public int testCenterId;
        public BaseProcess()
        {
            
        }
        public BaseProcess(int id,List<BaseDevice> devices)
        {
            this.Id = id;
            this.devices = devices;
            deviceCount = devices.Count;
        }
        public BaseProcess(List<BaseDevice> devices)
        {
            this.devices = devices;
            deviceCount = devices.Count;
        }
    }
}
