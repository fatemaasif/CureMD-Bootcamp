using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Management_System
{
    public interface ISoundBehaviour
    {
        void MakeSound();
    }
    public abstract class Animal
    {
        public string Name{get; set;}
        public string Species{get; set;}
        public int Age{get; set;}

        public Animal(string name, int age, string species)
        {
            Name = name;
            Age = age;
            Species = species;
        }
        public abstract void Eat();
        public abstract void Eat(string foodname);
    }
    public class Alpaca:Animal, ISoundBehaviour
    {
        public Alpaca(string name, int age):base(name,age,"Alpaca") {}
        public override void Eat() { Console.WriteLine("The Alpaca is eating!"); }
        public override void Eat(string foodname) { Console.WriteLine("The Alpaca is eating "+foodname+"!"); }
        public void ShornFur() { Console.WriteLine("The Alpaca is famous for its soft fur"); }
        public void MakeSound() {Console.WriteLine(Name+" the alpaca is humming");}
    }
    public class Emu:Animal, ISoundBehaviour
    {
        public Emu(string name, int age):base(name,age,"Emu") {}
        public override void Eat() { Console.WriteLine("The Emu is eating!"); }
        public override void Eat(string foodname) { Console.WriteLine("The Emu is eating " + foodname + "!"); }
        public void Run() { Console.WriteLine("The Emu is running; it can run quite fast!"); }
        public void MakeSound() {Console.WriteLine(Name+" the Emu is thumping");}
    }
    public class Panda:Animal, ISoundBehaviour 
    {
        public Panda(string name, int age):base(name,age,"Panda") {}
        public override void Eat() { Console.WriteLine("The Panda is eating!"); }
        public override void Eat(string foodname) { Console.WriteLine("The Panda is eating " + foodname + "!"); }
        public void Camouflage() { Console.WriteLine("The Panda is camouflaging!"); }
        public void MakeSound() {Console.WriteLine(Name+" the panda is squeaking");}
    }
    public class MuteSwan:Animal 
    {
        public MuteSwan(string name, int age):base(name,age,"Mute Swan") {}
        public override void Eat() { Console.WriteLine("The Mute Swan is eating!"); }
        public override void Eat(string foodname) { Console.WriteLine("The Mute Swan is eating " + foodname + "!"); }
        public void Fly() { Console.WriteLine("The Mute Swan is flying!"); }
    }
    public class Zoo
    {
        public List<Animal> Animals { get; set; }
        public Zoo()
        {
            Animals = new List<Animal>();
        }
        public void AddAnimal(Animal animalobj)
        {
            Animals.Add(animalobj);
            Console.WriteLine(animalobj.Name + " the " + animalobj.Species + " has been added to the Zoo");
        }
        public void FeedAllAnimals()
        {
            foreach (var a in Animals)
	        {  
                a.Eat();		 
	        }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            Alpaca alp = new Alpaca("Al",2);
            Emu E=new Emu("Em",4);
            Panda P=new Panda("Pan",6);
            MuteSwan MS = new MuteSwan("Swan",2);

            zoo.AddAnimal(alp);
            zoo.AddAnimal(E);
            zoo.AddAnimal(P);
            zoo.AddAnimal(MS);
            Console.WriteLine();

            zoo.FeedAllAnimals();
            Console.WriteLine();

            alp.ShornFur();
            E.Run();
            P.Camouflage();
            MS.Fly();
            Console.WriteLine();

            alp.Eat("grass");
            E.Eat("fruits");
            P.Eat("bamboos");
            MS.Eat("molluscs");
            Console.WriteLine();

            alp.MakeSound();
            E.MakeSound();
            P.MakeSound();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
