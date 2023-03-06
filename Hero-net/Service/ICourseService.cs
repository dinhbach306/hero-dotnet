namespace Hero_net.Service;

public interface ICourseService
{
    bool Enroll(Student student);

    int Enroll(List<Student> group);
}