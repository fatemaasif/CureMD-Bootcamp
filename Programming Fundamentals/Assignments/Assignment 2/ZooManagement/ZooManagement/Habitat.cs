namespace ZooManagement
{
    // The Habitat class represents the concept of association in OOP.
    // Association is a relationship between two classes that allows one object instance to cause another to perform an action on its behalf.
    public class Habitat
    {
        public string Name { get; set; }

        // The Animals property is a List<Animal>, which is a data structure that holds a sequence of elements. 
        // It is used to store the animals that live in the same habitat.
        private List<Animal> Animals { get; set; }

        public Habitat(string name)
        {
            Name = name;
            Animals = new List<Animal>();

            Console.WriteLine($"Added {name} Habitat to the Zoo.");
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
            Console.WriteLine($"Added {animal.Name} the {animal.Species} to the {Name} habitat.");
        }

        public List<Animal> GetAnimals()
        {
            return Animals;
        }
    }
}