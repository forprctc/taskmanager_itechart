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
        LogRepository logRepostitory = new LogRepository();
        Task_auditRepository task_auditRepository = new Task_auditRepository();
        public void MakeTask(TaskDTO taskDTO, bool isEvent)
        {
            
            DateTime date = new DateTime();
            try
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
                task=taskRepository.Create(task);
                int takePart=0;
                if(isEvent)
                {
                     takePart = 1;
                }
                else
                {
                     takePart = 2;
                }
                Task_auditDTO task_auditDTO = new Task_auditDTO
                {
                    status = takePart,
                    user_id = task.owner_id,
                    queue = 1
                };
                Mapper.Initialize(cfg => cfg.CreateMap<Task_auditDTO, Task_audit>());
                Task_audit task_audit = Mapper.Map<Task_auditDTO, Task_audit>(task_auditDTO);
                task_audit = task_auditRepository.Create(task_audit);
                LogDTO logDTO = new LogDTO
                {
                    status = 1,
                    date = date.Date,
                    task_id = task.task_id,
                    user_id = task.owner_id
                    
                    
                };
                Mapper.Initialize(cfg => cfg.CreateMap<LogDTO, Log>());
                Log log = Mapper.Map<LogDTO, Log>(logDTO);
                logRepostitory.Create(log); 

            }
            catch
            {

            }
          
        }
        public IEnumerable<TaskDTO> GetTasks()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Task, TaskDTO>());
            return Mapper.Map<IEnumerable<Task>, List<TaskDTO>>(taskRepository.GetAll());
        }
        public TaskDTO GetTask(int id)
        {
            var task = taskRepository.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Task, TaskDTO>());
            return Mapper.Map<Task, TaskDTO>(task);
        }
        public void Update(TaskDTO taskDTO, UserDTO userDTO)
        {
            
            DateTime date = new DateTime();
            LogDTO logDTO = new LogDTO
            {
                user_id = userDTO.user_id,
                task_id = taskDTO.task_id,
                status = taskDTO.status,
                date = date.Date

            };       
            Mapper.Initialize(cfg => cfg.CreateMap<TaskDTO, Task>());
            Task task=Mapper.Map<TaskDTO, Task>(taskDTO);
            taskRepository.Update(task);
        }
        public void Delete(TaskDTO taskDTO)
        {
            taskRepository.Delete(taskDTO.task_id);
        }
        
    }
}