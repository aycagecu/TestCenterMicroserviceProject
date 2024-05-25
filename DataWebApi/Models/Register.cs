using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataWebApi.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }
        public string tagName { get; set; }
        public string address { get; set; }
        public string Value { get; set; } // JSON formatında saklanacak alan
        public bool isWritable { get; set; }
        public bool isReadable { get; set; }

        [ForeignKey("BaseDevice")]
        public int deviceId;
        public Register()
        {
            
        }
        public Register(string tagName, string address, bool isReadable, bool isWritable, string value="" )
        {
            this.tagName = tagName;
            this.address = address;
            SetValue<string>(value);
            this.isWritable = isWritable;
            this.isReadable = isReadable;
        }



        public T GetValue<T>()
        {
            return JsonConvert.DeserializeObject<T>(Value);
        }

        public void SetValue<T>(T value)
        {
            Value = JsonConvert.SerializeObject(value);
        }
        public bool IsReadable()
        {
            return isReadable;
        }

        public bool IsWritable()
        { 
            return isWritable; 
        }
    }
}
