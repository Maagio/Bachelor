using Radiologi___Backend.Models;

namespace Radiologi___Backend.Storage
{
    public interface IClassDB
    {
        void CreateClass(Class newClass);
        Class GetClassById(string classId);
    }
}
