using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronSingleton
{
        public sealed class TaskManager
        {
            private static TaskManager instance = null;
            private static readonly object padlock = new object();

            private List<Task> tasks = new List<Task>();
            private int nextId = 1;

            private TaskManager() { }

            public static TaskManager Instance
            {
                get
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new TaskManager();
                        }
                        return instance;
                    }
                }
            }


            //Aquí vendría todos los métodos del task manager, agregar nueva tarea, listar tareas, cambiar estatus, etc
            public async Task<Task> CreateTask(string taskName, string taskDescription, string status, string priority)
            {
                var newTask = new Task(
                    nextId++,
                    taskName,
                    taskDescription,
                    status,
                    priority
                );
                tasks.Add(newTask);
                return newTask;
            }

            public List<Task> GetTasks()
            {
                return tasks;
            }

            public Task GetTaskById(int id)
            {
                return tasks.Find(t => t.taskId == id);
            }

            public void UpdateTaskStatus(int id, string status)
            {
                var task = GetTaskById(id);
                if (task != null)
                {
                    task.taskStatus = status;
                }
            }

            public void DeleteTask(int id)
            {
                var task = GetTaskById(id);
                if (task != null)
                {
                    tasks.Remove(task);
                }
            }
        }
    }
