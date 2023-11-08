using PatronSingleton;
using System;
using System.Threading.Tasks;
using Task = PatronSingleton.Task;

namespace PatronSingleton
{
    class Program
    {
        static async Task<int> Main()
        {
            var taskManager = TaskManager.Instance;

            while (true)
            {
                Console.WriteLine("================================");
                Console.WriteLine("Menú de Tareas");
                Console.WriteLine("1. Crear Tarea");
                Console.WriteLine("2. Mostrar Todas las Tareas");
                Console.WriteLine("3. Actualizar Estado de Tarea");
                Console.WriteLine("4. Eliminar Tarea");
                Console.WriteLine("5. Salir");
                Console.Write("Selecciona una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("================================");
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Nombre de la Tarea: ");
                            string name = Console.ReadLine();
                            Console.Write("Descripción de la Tarea: ");
                            string description = Console.ReadLine();
                            Console.Write("Estado de la Tarea: ");
                            string status = Console.ReadLine();
                            Console.Write("Prioridad de la Tarea: ");
                            string priority = Console.ReadLine();
                            var newTask = await taskManager.CreateTask(name, description, status, priority);
                            Console.WriteLine($"Tarea creada con ID {newTask.taskId}");
                            break;

                        case 2:
                            List<Task> tasks = taskManager.GetTasks();
                            if (tasks.Count == 0)
                            {
                                Console.WriteLine("No hay tareas disponibles.");
                            }
                            else
                            {
                                foreach (var task in tasks)
                                {
                                    Console.WriteLine($"ID: {task.taskId}");
                                    Console.WriteLine($"Nombre: {task.taskName}");
                                    Console.WriteLine($"Descripción: {task.taskDescription}");
                                    Console.WriteLine($"Estado: {task.taskStatus}");
                                    Console.WriteLine($"Prioridad: {task.taskPriority}\n");
                                }
                            }
                            break;

                        case 3:
                            Console.Write("ID de la Tarea a actualizar: ");
                            if (int.TryParse(Console.ReadLine(), out int idUpdate))
                            {
                                Console.Write("Nuevo Estado de la Tarea (Finalizada o Pendiente): ");
                                string newStatus = Console.ReadLine();
                                taskManager.UpdateTaskStatus(idUpdate, newStatus);
                                Console.WriteLine("Estado de la Tarea actualizado.");
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida para el ID de la Tarea.");
                            }
                            break;

                        case 4:
                            Console.Write("ID de la Tarea a eliminar: ");
                            if (int.TryParse(Console.ReadLine(), out int idDelete))
                            {
                                taskManager.DeleteTask(idDelete);
                                Console.WriteLine("Tarea eliminada.");
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida para el ID de la Tarea.");
                            }
                            break;

                        case 5:
                            return 0;

                        default:
                            Console.WriteLine("Opción no válida. Por favor, selecciona una opción válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, selecciona una opción válida.");
                    Console.WriteLine("================================");
                }
            }
        }
    }
}