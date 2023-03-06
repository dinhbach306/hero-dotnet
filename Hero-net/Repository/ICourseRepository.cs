namespace Hero_net.Repository;

public interface ICourseRepository
{
    bool Enroll(Student student);

    Student GetStudent(Student student);
}
