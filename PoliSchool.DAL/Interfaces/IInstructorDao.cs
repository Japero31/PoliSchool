using PoliSchool.DAL.Entities;
using school.DAL.Models;


namespace school.DAL.Interfaces
{
    public interface IInstructorDao
    {
        void SaveInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);
        void RemoveInstructor(Instructor instructor);
        List<InstructorModel> GetInstructors();
        InstructorModel GetInstructorById(int instructorId);
    }
}
