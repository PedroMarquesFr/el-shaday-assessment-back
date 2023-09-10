using AssessmentProject.Models;

namespace AssessmentProject.Service
{
    public interface IJwtProvider
    {
        string Generate(Person person);
    }
}
