﻿using DataWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace DataWebApi.Models
{
    public class TestCenter
    {
        [Key] public int Id { get; set; }
        public List<BaseProcess> processes {  get; set; }
        public TestCenter()
        {
            
        }
        public TestCenter(int id,List<BaseProcess> processes)
        {
            this.Id = id;
            this.processes = processes;
        }
        public TestCenter(List<BaseProcess> processes)
        {
            this.processes = processes;
        }
    }
}
