using Opl.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opl.Abstractions
{
    public interface IProjectsRepository
    {
        bool DeleteProject(int id);
        Project? GetProject(int id);
        IEnumerable<Project> GetProjects();
        int InsertProject(Project project);
        bool UpdateProject(Project project);
    }
}
