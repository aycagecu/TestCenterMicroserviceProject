using PLCRTUDataApi.Models;
using System.ComponentModel.DataAnnotations;

namespace PLCRTUDataApi.Models
{
    public class TestCenter
    {
        [Key] public int Id { get; set; }
        public List<BaseProcess> processes {  get; set; }
        public TestCenter()
        {
            
        }
        public TestCenter(List<BaseProcess> processes)
        {
            this.processes = processes;
        }
    }
}
