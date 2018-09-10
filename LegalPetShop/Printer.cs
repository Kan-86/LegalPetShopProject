using PetApp.Core.Entity;
using PetAppCore.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegalPetShop
{
    public class Printer: IPrinter
    {
        readonly IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        void IPrinter.StartUI()
        {
            string[] menuItems = {
                "List All Pets",
                "Add Pet",
                "Delete Pet",
                "Edit Pet",
                "Sort Pet by price",
                "Get 5 cheapest pets available",
                "Search for a specific type of a pet",
                "Exit"
            };
            Console.Clear();
            var selection = ShowMenu(menuItems);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        ShowAllPets();
                        break;
                    case 2:
                        AddPet();
                        break;
                    case 3:
                        DeletePet();
                        break;
                    case 4:
                        var idForEdit = PrintFindPetId();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        petToEdit.PetName= AskQuestion("Pet Name: ");
                        petToEdit.Price = double.Parse(AskQuestion("Price: "));
                        _petService.UpdatePet(petToEdit);
                        break;
                    case 5:
                        ShowPetByPrice();
                        break;
                    case 6:
                        Get5CheapestPets();
                        break;
                    case 7:
                        SearchPetType();
                        break;
                    default:
                        break;
                }
                
                selection = ShowMenu(menuItems);
                Console.Clear();
            }
            Console.WriteLine("Bye bye!");

            Console.ReadLine();
        }

        private void ShowPetByPrice()
        {
            var list = _petService.SortPetByPrice();
            foreach (var pet in list)
            {
                Console.WriteLine("Type: {0} Price: {1:N}", pet.PetType, pet.Price);
            }
        }

        private void Get5CheapestPets()
        {
            var list = _petService.Get5CheapestPets();
            foreach (var pet in list)
            {
                Console.WriteLine("Type: {0} Price: {1:N}", pet.PetType, pet.Price);
            }
        }

        private void SearchPetType()
        {
            var list = _petService.FindPetType();
            var input = Console.ReadLine();
            if (input.Contains("1"))
            {
                foreach (var pet in list)
                {
                    Console.WriteLine(pet.PetType + " " + pet.PetName);
                }
            }

        }

        private void DeletePet()
        {
            Console.WriteLine("Insert Pet ID, must contain a number above 0:");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id)
                   || id < 1)
            {
                Console.WriteLine("Incorrect input! Please select a number above 0");
            }
            _petService.DeletePet(id);
            Console.WriteLine("Pet with id {0} Deleted", id);
        }

        private void AddPet()
        {
            var pet = _petService.GetPetInstance();

            Console.WriteLine("Type Pet Name:");
            pet.PetName = Console.ReadLine();

            Console.WriteLine("Type Pet Color:");
            pet.Colour = Console.ReadLine();

            Console.WriteLine("Type Pet Type:");
            pet.PetType = Console.ReadLine();

            Console.WriteLine("Type Pet Previous Owner:");
            //pet.PetPreviousOwner = Console.ReadLine();



            Console.WriteLine("Type Pet Price:");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Please select a number between 20 - 50.000");
            }

            pet.Price = price;
            var petAdded = _petService.AddPet(pet);
            if (petAdded.Id > 0)
            {
                Console.WriteLine("Pet Added");
            }
        }

        private void ShowAllPets()
        {
            var listOfPets = _petService.GetPets();
            foreach (var pet in listOfPets)
            {
                Console.WriteLine($"Id: {pet.Id}\nColour: " +
                    $"{pet.Colour}\nNamee: {pet.PetName}\nType: " +
                    $"{pet.PetType}\nPrice: {pet.Price}\nPrevious Owner: " +
                    $"{pet.PetPreviousOwner} \nDetails: {pet.Details}\n"

            );}
        }

        int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Write a number to choose from the menu:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine((i+1) + ": " + menuItems[i]);
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                        || selection < 1
                        || selection > 9)
            {
                Console.WriteLine("Please select a number between 1 - 8");
            }

            return selection;
        }

        int PrintFindPetId()
        {
            Console.WriteLine("Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}
