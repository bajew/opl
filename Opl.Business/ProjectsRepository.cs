using LiteDB;
using Opl.Abstractions;
using Opl.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opl.Business
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly LiteDatabase db;

        public ProjectsRepository(LiteDatabase db)
        {
            this.db = db;
        }

        public IEnumerable<Project> GetProjects()
        {
            var projects = db.GetCollection<Project>("projects");
            foreach (var p in projects.Query().ToEnumerable())
            {
                yield return p;
            }
        }
        public Project? GetProject(int id)
        {
            var projects = db.GetCollection<Project>("projects");
            return projects.Query().Where(x => x.Id == id).SingleOrDefault();
        }
        public bool DeleteProject(int id)
        {
            var projects = db.GetCollection<Project>("projects");
            return projects.Delete(id);
        }
        public bool UpdateProject(Project project)
        {
            var projects = db.GetCollection<Project>("projects");
            var projectToUpdate = projects.Query().Where(x => x.Id == project.Id).SingleOrDefault();
            projectToUpdate.Name = project.Name;
            projectToUpdate.Description = project.Description;
            return projects.Update(projectToUpdate);
        }
        public int InsertProject(Project project)
        {
            var projects = db.GetCollection<Project>("projects");
            return projects.Insert(project);
        }

    }

}
