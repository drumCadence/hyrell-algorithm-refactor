using Algorithm.Models;

namespace Algorithm.Services
{
    public interface IAgeService
    {
        Answer FindClosestAges();
        Answer FindFurthestAges();
    }
}
