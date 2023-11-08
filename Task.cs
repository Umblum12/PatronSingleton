using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronSingleton
{
    public class Task
    {
        public int taskId {  get; set; }
        public string taskName { get; set; }
        public string? taskDescription { get; set; }
        public string taskStatus { get; set; }
        public string taskPriority { get; set; }

        public Task(int taskId, string taskName, string taskDescription, string taskStatus, string taskPriority) 
        {
            this.taskId = taskId;
            this.taskName = taskName;
            this.taskDescription = taskDescription;
            this.taskStatus = taskStatus;
            this.taskPriority = taskPriority;
        }
    }
}