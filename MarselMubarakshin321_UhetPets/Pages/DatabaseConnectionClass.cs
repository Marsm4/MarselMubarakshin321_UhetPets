using MarselMubarakshin321_UhetPets.Models;

namespace MarselMubarakshin321_UhetPets.Pages
{
    public static class DatabaseConnectionClass
    {
        public static Uhet_PetsEntities DatabaseConnection { get; } = new Uhet_PetsEntities();
    }
}