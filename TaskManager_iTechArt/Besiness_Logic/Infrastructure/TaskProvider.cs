using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager_iTechArt.Besiness_Logic.DTO;
using TaskManager_ITechArt.DAL.Repository;
using TaskManager_ITechArt.DAL.Entities;
using AutoMapper;
namespace TaskManager_iTechArt.Besiness_Logic.Infrastructure
{
    public class TaskProvider
    {
        TaskRepository taskRepository = new TaskRepository();
        public void MakeTask(TaskDTO taskDTO)
        {
            Task task = new Task
            {
                title = taskDTO.title,
                category = taskDTO.category,
                status = taskDTO.status,
                period = taskDTO.period,
                descriptions = taskDTO.descriptions,
                owner_id = taskDTO.owner_id,
                task_beginning = taskDTO.task_beginning,
                task_details = taskDTO.task_details,
                task_end = taskDTO.task_end
            };
            taskRepository.Create(task);
        }
        public IEnumerable<TaskDTO> GetTasks()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Task, TaskDTO>());
            return Mapper.Map<IEnumerable<Task>, List<TaskDTO>>(taskRepository.GetTasks());
        }
        public TaskDTO GetTask(int id)
        {
            var task = taskRepository.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Task, TaskDTO>());
            return Mapper.Map<Task, TaskDTO>(task);
        }
        public void Update(TaskDTO taskDTO)
        {

        }
    }
}